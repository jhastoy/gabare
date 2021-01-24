using UnityEngine;
using UnityEngine.SceneManagement;

public class AddGameObjectTest : MonoBehaviour
{
    public GameObject ajoutToit, ajoutCoffre;
    public GameObject velo, coffre;
    public string SceneToLoad;

    public GameObject Bicycle;

    void Start()
    {
        //ajoutCoffre.GetComponent<Renderer>().enabled = false;
        if (GameObject.Find("DataToSave") != null)
        {
            foreach(ItemOnCar item in GameObject.Find("DataToSave").GetComponent<ObjetOnCar>().ItemsOnCars)
            {
                if (item.Place == "Back")
                {
                    GameObject.Find("Add_Button_Track").SetActive(false);
                }
                GameObject go = Instantiate(Bicycle, new Vector3((float)item.Localx, (float)item.Localy, (float)item.Localz), Quaternion.identity);
                go.transform.parent = gameObject.transform;
                
            }


        }


    }
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                /*
                if (hit.collider.transform.parent.name == ajoutToit.name)
                {
                    ajoutToit.transform.GetChild(0).gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                    ajoutToit.transform.GetChild(1).gameObject.GetComponent<Renderer>().material.color = Color.yellow;
                }
                if (hit.collider.transform.parent.name == ajoutCoffre.name)
                {
                    Vector3 newV = new Vector3(coffre.GetComponent<Transform>().position.x, coffre.GetComponent<Transform>().position.y, coffre.GetComponent<Transform>().position.z);
                    velo = Instantiate(velo, gameObject.transform);
                    velo.GetComponent<Transform>().position = newV;
                    velo.GetComponent<Transform>().Rotate(0, 90, 0, 0);
                }*/

                if (hit.collider.transform.parent.name == ajoutToit.name)
                {
                    if (GameObject.Find("DataToSave") == null)
                    {
                        GameObject DataToSave = new GameObject();
                        DataToSave.name = "DataToSave";
                        DataToSave.AddComponent<ObjetOnCar>();
                        DataToSave.GetComponent<ObjetOnCar>().where = "Roof";
                        SceneManager.LoadScene(SceneToLoad);
                        DontDestroyOnLoad(DataToSave);
                    }
                    else
                    {
                        GameObject.Find("DataToSave").GetComponent<ObjetOnCar>().where = "Roof";
                        SceneManager.LoadScene(SceneToLoad);
                        DontDestroyOnLoad(GameObject.Find("DataToSave"));
                    }
                }

            if (hit.collider.transform.parent.name == ajoutCoffre.name)
                {
                    if (GameObject.Find("DataToSave") == null)
                    {
                        GameObject DataToSave = new GameObject();
                        DataToSave.name = "DataToSave";
                        DataToSave.AddComponent<ObjetOnCar>();
                        DataToSave.GetComponent<ObjetOnCar>().where = "Track";
                        SceneManager.LoadScene(SceneToLoad);
                        DontDestroyOnLoad(DataToSave);
                    }
                    else
                    {
                        GameObject.Find("DataToSave").GetComponent<ObjetOnCar>().where = "Track";
                        SceneManager.LoadScene(SceneToLoad);
                        DontDestroyOnLoad(GameObject.Find("DataToSave"));
                    }
                }

            }  
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (GameObject.Find("DataToSave") == null)
            {
                GameObject DataToSave = new GameObject();
                DataToSave.name = "DataToSave";
                DataToSave.AddComponent<ObjetOnCar>();
                DataToSave.GetComponent<ObjetOnCar>().where = "Back";
                SceneManager.LoadScene(SceneToLoad);
                DontDestroyOnLoad(DataToSave);
            }
            else
            {
                GameObject.Find("DataToSave").GetComponent<ObjetOnCar>().where = "Back";
                SceneManager.LoadScene(SceneToLoad);
                DontDestroyOnLoad(GameObject.Find("DataToSave"));
            }

            
        }



    }
}
