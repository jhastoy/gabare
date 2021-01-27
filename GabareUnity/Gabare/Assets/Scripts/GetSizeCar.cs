using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;


//Class pour afficher les dimensions totales (véhicule + équipements)
public class GetSizeCar : MonoBehaviour
{

    public GameObject TextLongueur, TextLargeur, TextHauteur; //Affichage à l'écran

    public int carLon, carLa, carHau; //dimensions du véhicule
    string chemin, jsongString;


    DimensionCar dimCar = new DimensionCar();
    // Start is called before the first frame update
    void Start()
    {
        //Si ce n'est pas la première ouverture des données, le GameObject empty "CarDim" n'a pas encore été crée
        //Sinon, c'est ce gameobjet qui va gérer la transmission des données de dimension du véhicule aux autres scènes
        if(GameObject.Find("CarDim") != null)
        {
            carLon = GameObject.Find("CarDim").GetComponent<CarDim>().carLongueur;
            carLa = GameObject.Find("CarDim").GetComponent<CarDim>().carLargeur;
            carHau = GameObject.Find("CarDim").GetComponent<CarDim>().carHauteur;
        }
        //Si c'est la première ouverture de l'application, récupération des valeurs dans le fichier json
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

        //Les données sauvées sont les données du véhicule + des conséquences de l'ajout d'équipement
        //Recalcul des dimensions
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
