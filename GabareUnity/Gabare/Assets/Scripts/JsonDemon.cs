using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonDemon : MonoBehaviour
{
    string chemin, jsonString;

    // Start is called before the first frame update
    void Start()
    {
        chemin = Application.streamingAssetsPath + "/listGameobjects.json";
        jsonString = File.ReadAllText(chemin);
        Objection obt = JsonUtility.FromJson<Objection>(jsonString);

        Debug.Log(obt.Nom);


        obt.Nom = "Batman";
        jsonString = JsonUtility.ToJson(obt);
        File.WriteAllText(chemin, jsonString);
    }

    
}

public class Objection
{
    public string Nom;
    public string Description;
}
