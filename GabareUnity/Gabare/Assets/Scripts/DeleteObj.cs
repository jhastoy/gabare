using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;




//Suppression d'un équiquement sur le véhicule en cliquant sur la croix rouge
public class DeleteObj : MonoBehaviour
{

    void Update()
    {
        if (Input.touchCount > 0)
        {
            PointerEventData pointer = new PointerEventData(EventSystem.current);
            pointer.position = Input.mousePosition;

            List<RaycastResult> raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointer, raycastResults);

            if (raycastResults.Count > 0 && raycastResults.Last().gameObject.name == gameObject.name)
            {
                foreach (ItemOnCar item in GameObject.Find("DataToSave").GetComponent<ObjetOnCar>().ItemsOnCars)
                {
                    if (item.Name == gameObject.transform.parent.name)
                    {
                        Destroy(GameObject.Find(item.Name + "(Clone)"));
                        GameObject.Find("DataToSave").GetComponent<ObjetOnCar>().ItemsOnCars.Remove(item);
                        Destroy(GameObject.Find(item.Name));

                    }

                }
            }
        }
    }
}
