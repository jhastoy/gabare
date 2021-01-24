using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeView : MonoBehaviour
{
    public string SceneToLoad;

    // Update is called once per frame
    void Update()
    {

        if (Input.touchCount>0)
        {
            PointerEventData pointer = new PointerEventData(EventSystem.current);
            pointer.position = Input.mousePosition;

            List<RaycastResult> raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointer, raycastResults);

            if (raycastResults.Count > 0 && raycastResults.Last().gameObject.name==gameObject.name)
            {
                SceneManager.LoadScene(SceneToLoad);

                if (GameObject.Find("DataToSave") != null)
                {
                    DontDestroyOnLoad(GameObject.Find("DataToSave"));
                }
            }
        }
        

        /*if (Input.touchCount > 0)
        {

            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {

                SceneManager.LoadScene(SceneToLoad);
                //so when the user touched the UI(buttons) call your UI methods 
            }
            else
            {
                Debug.Log("UI is not touched");
                //so here call the methods you call when your other in-game objects are touched 
            }
        }*/

    }
}
