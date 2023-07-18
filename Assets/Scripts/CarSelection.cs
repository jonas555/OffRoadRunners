using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelection : MonoBehaviour
{
    public static int carType;
    public GameObject track;
    public GameObject firebird;
    public GameObject miura;
    public GameObject inactiveMiura;
    public GameObject activeMiura;
    public GameObject activeSkirmish;
    public GameObject inactiveSkirmish;
    public GameObject firebirdColor;
    public GameObject miuraColor;

    public Color colorSelect;
    public Material[] vehicleColors;
    public int carSelected;

    public int bronze;

    void Start()
    {
        bronze = PlayerPrefs.GetInt("bronze");
        carSelected = CarSelection.carType;
        if(bronze == 1)
        {
            activeMiura.SetActive(true);
            activeSkirmish.SetActive(true);
            inactiveMiura.SetActive(false);
            inactiveSkirmish.SetActive(false);
        }
    }

    public void SetVehicleType(int a)
    {
        carType = carSelected;
        carSelected = a;
    }

    public void Firebird()
    {
        carSelected = 0;       
        track.SetActive(true);
        firebird.SetActive(true);
        firebirdColor.SetActive(true);
        miuraColor.SetActive(false);
        miura.SetActive(false);
    }

    public void Miura()
    {
        carSelected = 1;
        track.SetActive(true);
        miura.SetActive(true);
        miuraColor.SetActive(true);
        firebirdColor.SetActive(false);
        firebird.SetActive(false);
        inactiveMiura.SetActive(false);
    }

    //converting color values
    public void ColorSelection(string hex) //hex value
    {
        hex = hex.Replace("0x", "");//if it is formatted as 0xFFFFFF
        hex = hex.Replace("#", "");//if it is formatted # values #FFFFFF

        //converts into basic alpha numerical value and converts hex to an rgb values
        byte a = 255;
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);

        if(hex.Length == 8)//if the values are 8 as it should be
        {
            //bitwise combination of enumeration values that indicates the style elements
            //start converting into rgb numerical values
            a = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        }
        colorSelect = new Color32(r, g, b, a);//basic color is selected based on the chosen color rgb

        vehicleColors[carSelected].color = colorSelect;//chosen vehicle color while it is selected is replaced with the chosen color
    }
}
