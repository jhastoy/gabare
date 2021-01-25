using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;





public class DeleteObj : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
