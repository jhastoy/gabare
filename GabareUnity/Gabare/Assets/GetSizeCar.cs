using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GetSizeCar : MonoBehaviour
{

    public GameObject TextLongueur, TextLargeur, TextHauteur;

    public int carLon, carLa, carHau;
    string chemin, jsongString;


    DimensionCar dimCar = new DimensionCar();
    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("CarDim") != null)
        {
            carLon = GameObject.Find("CarDim").GetComponent<CarDim>().carLongueur;
            carLa = GameObject.Find("CarDim").GetComponent<CarDim>().carLargeur;
            carHau = GameObject.Find("CarDim").GetComponent<CarDim>().carHauteur;
        }
        else
        {
            chemin = Application.streamingAssetsPath + "/carDimension.json";
            jsongString = File.ReadAllText(chemin);
            dimCar = JsonUtility.FromJson<DimensionCar>(jsongString);

            if (dimCar.Longueur != 0 && dimCar.Largeur != 0 && dimCar.Hauteur != 0)
            {
                carLon = dimCar.Longueur;
                carLa = dimCar.Largeur;
                carHau = dimCar.Hauteur;
            }
        }

        if (GameObject.Find("DataToSave") != null)
        {
            foreach (ItemOnCar item in GameObject.Find("DataToSave").GetComponent<ObjetOnCar>().ItemsOnCars)
            {
               if (item.Place == "Roof")
                {
                    carHau += item.Hauteur;
                    if(item.Largeur > carLa)
                    {
                        carLa = item.Largeur;
                    }
                }
                else
                {
                    if (item.Rotation == 90)
                    {
                        if(item.Longueur > carLa)
                        {
                            carLa = item.Longueur;
                        }
                        carLon += item.Hauteur;
                    }
                    else
                    {
                        carLon += item.Longueur;
                        if(item.Largeur > carLa)
                        {
                            carLa = item.Largeur;
                        }
                        if (item.Hauteur > carHau)
                        {
                            carHau = item.Hauteur;
                        }
                    }
                }

            }
        }
        TextLongueur.GetComponent<Text>().text = TextLongueur.GetComponent<Text>().text + " " + carLon.ToString() + " cm";
        TextLargeur.GetComponent<Text>().text = TextLargeur.GetComponent<Text>().text + " " + carLa.ToString() + " cm";
        TextHauteur.GetComponent<Text>().text = TextHauteur.GetComponent<Text>().text + " " + carHau.ToString() + " cm";


    }


}
