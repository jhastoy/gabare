using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

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

	void Start()
	{
		GameObject buttonTemplate = transform.GetChild(0).gameObject;
		GameObject g;

		int N = allObjects.Length;

		for (int i = 0; i < N; i++)
		{
			g = Instantiate(buttonTemplate, transform);
			g.transform.GetChild(0).GetComponent<Image>().sprite = allObjects[i].Icon;
			g.transform.GetChild(1).GetComponent<Text>().text = allObjects[i].Name;
			g.transform.GetChild(2).GetComponent<Text>().text = allObjects[i].Description;

			/*g.GetComponent <Button> ().onClick.AddListener (delegate() {
				ItemClicked (i);
			});*/
			g.GetComponent<Button>().AddEventListener(i, ItemClicked);
		}

		Destroy(buttonTemplate);
	}

	void ItemClicked(int itemIndex)
	{
		Debug.Log("------------item " + itemIndex + " clicked---------------");
		Debug.Log("name " + allObjects[itemIndex].Name);
		Debug.Log("desc " + allObjects[itemIndex].Description);
	}
}
