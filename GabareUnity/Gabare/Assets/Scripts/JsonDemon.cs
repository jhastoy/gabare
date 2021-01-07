using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonDemon : MonoBehaviour
{
    public TextAsset textJSON;

    

    public ObjetList myObjetsList = new ObjetList();

    
    string chemin, jsonString;

    // Start is called before the first frame update
    void Start()
    { 
        chemin = Application.streamingAssetsPath + "/listGameobjects.json";
        jsonString = File.ReadAllText(chemin);
        /*Objection obt = JsonUtility.FromJson<Objection>(jsonString);

        Debug.Log(obt.Nom);


        obt.Nom = "Batman";
        jsonString = JsonUtility.ToJson(obt);
        File.WriteAllText(chemin, jsonString);
        */
       myObjetsList = JsonUtility.FromJson<ObjetList>(jsonString);
    }


    
}
[System.Serializable]
public class Objet
{
    public string Nom;
    public string Description;
    public int Longueur;
    public int Largeur;
    public int Hauteur;
}

[System.Serializable]
public class ObjetList
{
    public Objet[] objet;
}



