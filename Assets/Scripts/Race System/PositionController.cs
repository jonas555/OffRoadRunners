using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PositionController : MonoBehaviour
{
    [Header("Add the cars here. The player Object should have the Player boolean set to true")]
    public Car[] Cars; //list of cars that you want to add in the track
    //   private int[] PlacingTracking;
    public Waypoints _WaypointContainer; //The waypoints of the position count
    private float[] A; //used as a memory list for the algorithm.
    private Car[] SavedList; //Save the list of cars
    [Space]
    [Header("UI")]
    public TMP_Text PlayerPosition;
    public TMP_Text NumberOfPlayers;
    int playerPlaceInArray; //the players position value
    public bool UsesFinishLapCollider; //checks if finish line collider has been trigered

    [System.Serializable]
    public class Waypoints
    {
        public List<Transform> wp = new List<Transform>();
        public float radius = 45f;
    }

    [System.Serializable]
    public class Car
    {
        public bool Player; //check if player is present
        [HideInInspector]
        public string Name; //the name of the players?
        public Transform CarTransform; //objects position
        public float CarHeight; //height of the object?
        [HideInInspector]
        public int CurrentPosition;
        [HideInInspector]
        public float distance; //distance of reaching the radius of the sphere?
        [HideInInspector]
        //a float that is used if the car is ahead or at the same position of the waypoint...
        public float finalConverted; //if its the same position as the waypoint, calculate the distance between them to know which is further ahead
        [HideInInspector]
        public int CurrentLap = 1;
        [HideInInspector]
        public GameObject PositionText;

        void Start()
        {
            CarTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
    }

    void Start()
    {        
        //used for the sorting algorithm
        A = new float[Cars.Length]; //sorting list of cars

        //the list the algorithm sorts
        SavedList = new Car[Cars.Length]; //gets the list of cars and saves them to the SavedList variable

        SavedList = Cars; //the list is equals to the cars that are placed in track

        //checks if the number of players is not empty and if the manager of the lap controler set it up correctly
        if (NumberOfPlayers != null)
        {
            //Sets the number of players in the text
            NumberOfPlayers.text = "/" + Cars.Length;
        }
        //Throw error if the manager not responding
        else
        {
            Debug.LogError("You have not set up SCPS Correctly");
        }        
    }

    void Update()
    {
        //check if the player is allowed to move based on the script
        CalculateCheckpoints();
        CalculatePositions();
        UpdateUI();
    }

    //Updates the ui to show the correct information needed
    void UpdateUI()
    {
        //Player place list
        string CurrentList = ""; //list of cars name variable (is it required even though I dont have in my game the display name list)
        int b = 1; //value of the position

        //for loop decreases the position when it finds the list of cars
        //that is done due to the ui text showing the strings from last to first so you basically just invert the saved list
        for (int i = SavedList.Length - 1; i >= 0; i--) //loop through the list by decending (-1), equals to 0 and increment decrease
        {
            CurrentList += (b) + ". " + Cars[i].Name + "\n"; //adds the vehicles names and position
            b++;//adds/increases the position
        }
    }

    //Algorithm to calculate what checkpoint each car is
    void CalculateCheckpoints()
    {
        foreach (Car c in Cars)//for each car...
        {
            //Enable The checkpoint renderer if its next
            if (c.distance < _WaypointContainer.radius)//if the car distance is less than the radius of the sphere...
            {
                if (c.CurrentPosition + 1 < _WaypointContainer.wp.Count)//and if the car current position increased less than the count of the list of waypoints that has been passed
                {
                    c.CurrentPosition++; //increase the position
                }
                //check for lap Position
                else
                {
                    PassedLapLine(c);//used to calculate the place if there are laps in the game 
                    //If this is not used it would cause a number of problems like lap 1, car waypoint 0 being percived as behind lap 0.
                }
            }

            //calculation of the car distance between the distance of transform position and waypoints list transform [with cars current position] transform position
            //calculates the distance of the car from the waypoint
            //used to know which 2 cars is closer to the waypoint is ahead
            c.distance = Vector3.Distance(c.CarTransform.position, _WaypointContainer.wp[c.CurrentPosition].transform.position);

            //a quick math hack to sort on which waypoint each car is. Used for the sorting.
            //used to get the list of cars that has passed wp-1 on lap 1 and the other car that has passed lap 2 and passed the wp-1, making less confusing to check which one of them is ahead
            c.finalConverted = (float)c.CurrentLap * (float)_WaypointContainer.wp.Count + ((float)c.CurrentPosition + 1 / ((float)c.distance + 1f));
        }

        //loop through the list of cars again from 0
        for (int i = 0; i < Cars.Length; i++)
        {
            A[i] = Cars[i].finalConverted; //A (as list) = list of cars position and lap count that has been converted after passing finish line
        }

        //after the final conversion (lap has been completed) update the list of cars and saved list of them
        SelectionSort(Cars, SavedList);


    }

    //Not sure about the passedlapline
    void PassedLapLine(Car c)
    {
        c.CurrentLap++; //when the player passes the next lap it needs to reset and keep track of what lap the player is so that it doesnt mistake the cars that are on the last lap as being ahead.
        c.CurrentPosition = 0;
    }

    //cars that triggered the finish line after completing the track lap
    public void HittedFinishLine(Collider col)
    {
        foreach (Car c in Cars)//for each cars...
        {
            //checks if the player actually gor through the lap the correct way by passing through all the checkpoints and did not simply go reverse the track and glitch it
            if (col.transform.IsChildOf(c.CarTransform))//get the cars collider within the child of it
            {
                //How would I describ this if statement?
                if (c.CurrentPosition + 1 < _WaypointContainer.wp.Count)//if the car current position is increased by 1 less than the count of the list of waypoints
                {
                    if (c.CurrentLap > 1)//checks if the players lap is on the lap 2 or greater...
                    {
                        Debug.LogError("FinishLine Should be on last checkpoint");
                    }
                }
                //check for lap Position
                else
                {
                    PassedLapLine(c);
                }
            }
        }
    }

    //returns the player's position
    int GetPlayerPosition()
    {
        int b = 1; //the player position value

        //loop through saved list
        for (int i = SavedList.Length - 1; i >= 0; i--)//get the saved list decreased by 1, greater/eqauls than 0 and 
        {
            if (Cars[i].Player) //if the player from the list is not a player...
            {
                return b;//return default
            }
            else
            {
                b++;//increase
            }
        }
        return 0;//if null/set 0
    }

    //The selection sort alogithm
    void SelectionSort(Car[] car, Car[] B)//get the cars list and the cars saved list...
    {
        int size = car.Length; //size as list of cars variable

        //loop through the first list 
        for (int i = 0; i < size - 1; i++)
        {
            int Imin = i;//variable of  second list?
            for (int j = i + 1; j < size; j++)//loop through the first with increase of 1
            {
                if (A[j] < A[Imin])//if the second list is less than the first
                {
                    Imin = j;//the first list of cars is equals to the second list of cars?
                }
            }
            float temp = A[Imin];//list of A cars (first list)
            Car temp2 = B[Imin];//list of B cars (second list)
            A[Imin] = A[i];//sorting out in reverse
            B[Imin] = B[i];
            A[i] = temp;
            B[i] = temp2;
        }
    }

    //calculate's positions based on the sorted list
    void CalculatePositions()
    {
        int b = 0; //variable of position
        for (int i = SavedList.Length - 1; i >= 0; i--)//loop through the the saved list of cars in reverse, greater/equals than 0, go down of the position
        {
            b++; //increase the position
            if (SavedList[i].Player && PlayerPosition != null)//if savedlist with the player active & position of the players is not null
            {
                playerPlaceInArray = i;//place the player to the position based of the cars list placed on track for passing them
                PlayerPosition.text = b.ToString();//update the position text

            }

            //Not usable at the moment
            //update UI text here
            if (SavedList[i].PositionText)//if position text is active
            {
                float distance = Vector3.Distance(SavedList[i].CarTransform.position, Camera.main.transform.position);//get the cameras distance and the saved list of cars transform position?
                if (distance < 20f)//if the players and AI's distance are less than 20f (of their distance before passing eash other)
                {
                    SavedList[i].PositionText.GetComponent<TMP_Text>().text = b + " : " + SavedList[i].Name;
                }
                else if (distance < 60f)//if less then 60f of passing each other, depending on how close you are about to pass one another
                {
                    SavedList[i].PositionText.GetComponent<TMP_Text>().text = b.ToString();
                }
                else //leave an empty string if one of them didn't pass each other correctly?
                {
                    SavedList[i].PositionText.GetComponent<TMP_Text>().text = "";
                }
                //Update the text
                //the text of showing the cars placement in the 3D world               
                SavedList[i].PositionText.transform.position = SavedList[i].CarTransform.position + Vector3.up * SavedList[i].CarHeight;
                SavedList[i].PositionText.transform.rotation = Camera.main.transform.rotation;
            }
        }

    }
}
