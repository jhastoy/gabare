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
        //On vérifie s'il y a des équipements sur la voiture
        //Ici : qu'un objet sur le toit et qu'un objet au niveau du coffre
        if (GameObject.Find("DataToSave") != null)
        {
            foreach(ItemOnCar item in GameObject.Find("DataToSave").GetComponent<ObjetOnCar>().ItemsOnCars)
            {
                if (item.Place == "Track")
                {
                    GameObject.Find("Add_Button_Track").SetActive(false);
                }
                else
                {
                    GameObject.Find("Add_Button_Roof").SetActive(false);
                }
                //Affichage du vélo à l'écran
                //La gestion avec d'autres gameobjets n'a pas été faite
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
                //Gestion du clic sur le plus du toit

                if (hit.collider.transform.parent.name == ajoutToit.name)
                {
                    //Si le GameObject DataToSave n'existe pas on le crée pour sauvegardée nos données sur l'équipement du véhicule à travers les scènes

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
            //Gestion du clic sur le plus du coffre
            if (hit.collider.transform.parent.name == ajoutCoffre.name)
                {
                    //Si le GameObject DataToSave n'existe pas on le crée pour sauvegardée nos données sur l'équipement du véhicule à travers les scènes
                    if (GameObject.Find("DataToSave") == null)
                    {
                        GameObject DataToSave = new GameObject();
                        DataToSave.name = "DataToSave";
                        DataToSave.AddComponent<ObjetOnCar>();
                        DataToSave.GetComponent<ObjetOnCar>().where = "Track";
                        SceneManager.LoadScene(SceneToLoad);
                        DontDestroyOnLoad(DataToSave);
                    }
                    //Sinon mis à jour des données
                    else
                    {
                        GameObject.Find("DataToSave").GetComponent<ObjetOnCar>().where = "Track";
                        SceneManager.LoadScene(SceneToLoad);
                        DontDestroyOnLoad(GameObject.Find("DataToSave"));
                    }
                }

            }  
        }


    }
}
