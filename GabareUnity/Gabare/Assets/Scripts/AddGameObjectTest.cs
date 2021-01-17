using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class AddGameObjectTest : MonoBehaviour
{
    public GameObject ajoutToit, ajoutCoffre;
    public GameObject velo, coffre;

    void Start()
    {
        //ajoutCoffre.GetComponent<Renderer>().enabled = false;
        

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
                print(hit.collider.transform.parent.name) ;
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
                }
            }

            
        }

        

    }
}
