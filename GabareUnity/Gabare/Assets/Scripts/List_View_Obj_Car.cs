﻿using System.Collections;
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
		if (GameObject.Find("DataToSave")==null)
        {
			gameObject.SetActive(false);
        }
        else
        {
			GameObject buttonTemplate = transform.GetChild(0).gameObject;
			GameObject g;

			foreach (ItemOnCar item in GameObject.Find("DataToSave").GetComponent<ObjetOnCar>().ItemsOnCars)
			{
				g = Instantiate(buttonTemplate, transform);
				g.name = item.Name;
				g.transform.GetChild(0).GetComponent<Text>().text = item.Name;
				g.transform.GetChild(1).GetComponent<Text>().text = "Longueur : " + item.Longueur.ToString();
				g.transform.GetChild(2).GetComponent<Text>().text = "Largeur : " + item.Largeur.ToString();
				g.transform.GetChild(3).GetComponent<Text>().text = "Hauteur : " + item.Hauteur.ToString();
				g.transform.GetChild(4).GetComponent<Button>().AddEventListener(item, ItemClicked);

			}
			Destroy(buttonTemplate);

		}


	}

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


