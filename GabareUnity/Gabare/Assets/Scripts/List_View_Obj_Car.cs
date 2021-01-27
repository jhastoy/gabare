using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class List_View_Obj_Car : MonoBehaviour
{
	public GameObject Button_Track;
	public GameObject Button_Roof;
    // Start is called before the first frame update
    void Start()
    {
		//S'il n'y a pas ce GameObjet, aucune donnée n'a été ajoutée ou modifiée depuis le lancement de l'application
		if (GameObject.Find("DataToSave")==null)
        {
			gameObject.SetActive(false);
        }
		//Affichage de la liste des équipements présents sur la voiture avec leur dimensions
        else
        {
			GameObject buttonTemplate = transform.GetChild(0).gameObject;
			GameObject g;

			foreach (ItemOnCar item in GameObject.Find("DataToSave").GetComponent<ObjetOnCar>().ItemsOnCars)
			{
				g = Instantiate(buttonTemplate, transform);
				g.name = item.Name;
				g.transform.GetChild(0).GetComponent<Text>().text = item.Name;
				g.transform.GetChild(1).GetComponent<Text>().text = "Longueur : " + item.Longueur.ToString() + " cm";
				g.transform.GetChild(2).GetComponent<Text>().text = "Largeur : " + item.Largeur.ToString() + " cm";
				g.transform.GetChild(3).GetComponent<Text>().text = "Hauteur : " + item.Hauteur.ToString() + " cm";
				g.transform.GetChild(4).GetComponent<Button>().AddEventListener(item, ItemClicked);

			}
			Destroy(buttonTemplate);

		}


	}

	//Gestion du clic sur la croix rouge, qui va supprimer l'équipement du véhicule et redonner la possibilité à l'utilisateur d'en ajouter un autre
	void ItemClicked(ItemOnCar item2)
	{
			foreach (ItemOnCar item in GameObject.Find("DataToSave").GetComponent<ObjetOnCar>().ItemsOnCars)
			{
				if (item.Name == item2.Name)
				{
					if (item2.Place == "Roof")
					{
						Button_Roof.SetActive(true);
					}
					else
					{
						Button_Track.SetActive(true);
					}

					Destroy(GameObject.Find(item.Name + "(Clone)"));
					GameObject.Find("DataToSave").GetComponent<ObjetOnCar>().ItemsOnCars.Remove(item);
					if (GameObject.Find("DataToSave").GetComponent<ObjetOnCar>().ItemsOnCars.Count == 0)
					{
					Destroy(GameObject.Find(item.Name).transform.parent.gameObject);
					}
					else
					{
						Destroy(GameObject.Find(item.Name));
					}


				}

			}
		
	}
}


