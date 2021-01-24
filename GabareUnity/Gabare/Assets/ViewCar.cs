using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ViewCar : MonoBehaviour
{
    public GameObject Bicycle;
    // Start is called before the first frame update
    void Start()
    {

        if (GameObject.Find("DataToSave") != null)
        {
            print("nb" + GameObject.Find("DataToSave").GetComponent<ObjetOnCar>().ItemsOnCars.Count);
                foreach (ItemOnCar item in GameObject.Find("DataToSave").GetComponent<ObjetOnCar>().ItemsOnCars)
                {
                GameObject newGo = Instantiate(Bicycle, new Vector3((float)item.Localx, (float)item.Localy, (float)item.Localz), Quaternion.identity);
                newGo.transform.parent = gameObject.transform;

                }
            
        }
    }

    
}
