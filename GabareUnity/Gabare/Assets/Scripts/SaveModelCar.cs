﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SaveModelCar : MonoBehaviour
{
    public GameObject InputLongueur, Inputlargeur, InputHauteur;


    public GameObject Warning; //GameObject Text d'un message d'erreur d'input d'entrée par l'utilisateur

    string chemin, jsongString;


    DimensionCar dimCar = new DimensionCar();



    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Image>().enabled = false;
        gameObject.transform.GetChild(0).gameObject.SetActive(false);

        chemin = Application.streamingAssetsPath + "/carDimension.json";
        jsongString = File.ReadAllText(chemin);
        dimCar = JsonUtility.FromJson<DimensionCar>(jsongString);


        if (dimCar.Longueur != 0 && dimCar.Largeur !=0 && dimCar.Hauteur != 0)
        {
            InputLongueur.GetComponent<InputField>().text = dimCar.Longueur.ToString();
            Inputlargeur.GetComponent<InputField>().text = dimCar.Largeur.ToString();
            InputHauteur.GetComponent<InputField>().text = dimCar.Hauteur.ToString();
            if (GameObject.Find("CarDim") != null)
            {
                GameObject.Find("CarDim").GetComponent<CarDim>().CarDimension(dimCar.Longueur, dimCar.Largeur, dimCar.Hauteur);
            }
            else             //Creation d'un GameObject Empty avec un script pour enregistrer les données du véhicule et les faire passer de scène en scène (objet non détruit)

            {
                GameObject go = new GameObject();
                go.name = "CarDim";
                go.AddComponent<CarDim>();
                go.GetComponent<CarDim>().CarDimension(dimCar.Longueur, dimCar.Largeur, dimCar.Hauteur);
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        //mise à jour des valeurs du véhicules
        //en cas de changement, apparition du bouton "Enregistrer)
        if(InputLongueur.GetComponent<InputField>().text != dimCar.Longueur.ToString() || Inputlargeur.GetComponent<InputField>().text != dimCar.Largeur.ToString()|| InputHauteur.GetComponent<InputField>().text != dimCar.Hauteur.ToString())
        {
            if (Int32.TryParse(InputLongueur.GetComponent<InputField>().text, out dimCar.Longueur) && Int32.TryParse(Inputlargeur.GetComponent<InputField>().text, out dimCar.Largeur) && Int32.TryParse(InputHauteur.GetComponent<InputField>().text, out dimCar.Hauteur))
            {
                gameObject.GetComponent<Image>().enabled = true;
                gameObject.transform.GetChild(0).gameObject.SetActive(true);

            }
            else
            {
                Warning.SetActive(true); // message d'erreur si mauvaise entrée de l'utilisateur
            }
        }


        //Sauvegarde dans le fichier JSON pour conserver les données
        if (Input.touchCount > 0)
        {
            PointerEventData pointer = new PointerEventData(EventSystem.current);
            pointer.position = Input.mousePosition;

            List<RaycastResult> raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointer, raycastResults);

            if (raycastResults.Count > 0 && raycastResults.Last().gameObject.name == gameObject.name)
            {
                GameObject.Find("CarDim").GetComponent<CarDim>().CarDimension(dimCar.Longueur, dimCar.Largeur, dimCar.Hauteur);
                jsongString = JsonUtility.ToJson(dimCar);
                File.WriteAllText(chemin, jsongString);

            }
        }
    }
}

//Class qui sert à extraire le fichier JSON


public class DimensionCar
{
    public int Longueur;
    public int Largeur;
    public int Hauteur;
}
