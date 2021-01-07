using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

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
		public Objet[] objet;
	}

	//public TextAsset textJSON;



	public ObjetList myObjetsList = new ObjetList();


	string chemin, jsonString;

	/// <summary>
	/// ///
	/// </summary>



	void Start()
	{
		chemin = Application.streamingAssetsPath + "/listGameobjects.json";
		jsonString = File.ReadAllText(chemin);
		myObjetsList = JsonUtility.FromJson<ObjetList>(jsonString);
		//print(myObjetsList.objet.Length);


		GameObject buttonTemplate = transform.GetChild(0).gameObject;
		GameObject g;

		
		int N = myObjetsList.objet.Length;

		for (int i = 0; i < N; i++)
		{

			g = Instantiate(buttonTemplate, transform);
			g.transform.GetChild(0).GetComponent<Text>().text = myObjetsList.objet[i].Largeur.ToString();
			g.transform.GetChild(1).GetComponent<Text>().text = myObjetsList.objet[i].Nom;
			g.transform.GetChild(2).GetComponent<Text>().text = myObjetsList.objet[i].Description;

			/*g.GetComponent <Button> ().onClick.AddListener (delegate() {
				ItemClicked (i);
			});*/
			g.GetComponent<Button>().AddEventListener(i, ItemClicked);
		}

		Destroy(buttonTemplate);

		////////////////////////////// AJOUT D'UN OBJET //////////////////////////////
        

        /*
		Objet monobj = new Objet("Papi", "Velo", 12, 14, 35);
		myObjetsList.objet[3] = monobj;
		jsonString = JsonUtility.ToJson(myObjetsList);
		File.WriteAllText(chemin, jsonString); */
	}

	void ItemClicked(int itemIndex)
	{
		Debug.Log("------------item " + itemIndex + " clicked---------------");
		Debug.Log("name " + myObjetsList.objet[itemIndex].Nom);
		Debug.Log("desc " + myObjetsList.objet[itemIndex].Description);
	}
}
