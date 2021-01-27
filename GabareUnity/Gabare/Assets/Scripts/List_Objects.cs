using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using UnityEngine.SceneManagement;

public static class ButtonExtension
{
    public static void AddEventListener<T>(this Button button, T param, Action<T> OnClick)
    {
        button.onClick.AddListener(delegate () {
            OnClick(param);
        });
    }
}



public class List_Objects : MonoBehaviour
{
	//public GameObject Passeur;

	[Serializable]
	public struct Objects
	{
		public string Name;
		public string Description;
		public Sprite Icon;
	}

	[SerializeField] Objects[] allObjects;

	/// <summary>
    /// ///////
    /// </summary>

	[System.Serializable]
	public class Objet
	{
		public string Nom;
		public string Description;
		public int Longueur;
		public int Largeur;
		public int Hauteur;
		

		public Objet(string _nom, string _description, int _longueur, int _largeur, int _hauteur)
        {
			Nom = _nom;
			Description = _description;
			Longueur = _longueur;
			Largeur = _largeur;
			Hauteur = _hauteur;
        }
	}
	
	

	[System.Serializable]
	public class ObjetList
	{
		public List<Objet> objet;
	}


	public ObjetList myObjetsList = new ObjetList();


	string chemin, jsonString;





	void Start()
	{
		chemin = Application.streamingAssetsPath + "/listGameobjects.json";
		jsonString = File.ReadAllText(chemin);
		myObjetsList = JsonUtility.FromJson<ObjetList>(jsonString);


		GameObject buttonTemplate = transform.GetChild(0).gameObject;
		GameObject g;

		int N = myObjetsList.objet.Count;

		for (int i = 0; i < N; i++)
		{

			g = Instantiate(buttonTemplate, transform);
			g.transform.GetChild(0).GetComponent<Text>().text = myObjetsList.objet[i].Nom;
			g.transform.GetChild(1).GetComponent<Text>().text = myObjetsList.objet[i].Description;
			g.transform.GetChild(2).GetComponent<Text>().text = "Longueur : " + myObjetsList.objet[i].Longueur.ToString() + " cm";
			g.transform.GetChild(3).GetComponent<Text>().text = "Largeur : " + myObjetsList.objet[i].Largeur.ToString() + " cm";
			g.transform.GetChild(4).GetComponent<Text>().text = "Hauteur : " + myObjetsList.objet[i].Hauteur.ToString() + " cm";

			
			g.GetComponent<Button>().AddEventListener(i, ItemClicked);
		}

		Destroy(buttonTemplate);

		////////////////////////////// AJOUT D'UN OBJET //////////////////////////////
        

        /*
		Objet monobj = new Objet("telr", "TICTAC", 12, 14, 35);
		myObjetsList.objet.Add(monobj);
		jsonString = JsonUtility.ToJson(myObjetsList);
		File.WriteAllText(chemin, jsonString); */
	}

	void ItemClicked(int itemIndex)
	{
		double localx;
		double localy;
		double localz;

		int orientation = 0;

		//Valeurs entrées en dur pour le démonstrateur
        if (myObjetsList.objet[itemIndex].Nom == "Velo") 
        {
			localx = -1.83;
			localy = -0.24;
			localz = -6.47;
			orientation = 90;
        }
        else
        {
			localx = 0;
			localy = 0;
			localz = 0;
        }

		GameObject.Find("DataToSave").GetComponent<ObjetOnCar>().ItemPotentielInfo(myObjetsList.objet[itemIndex].Nom, myObjetsList.objet[itemIndex].Longueur, myObjetsList.objet[itemIndex].Largeur, myObjetsList.objet[itemIndex].Hauteur, localx, localy, localz, orientation);
		SceneManager.LoadScene("Personnalisation");
		DontDestroyOnLoad(GameObject.Find("DataToSave"));
	}
}

