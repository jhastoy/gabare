using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class CarResearch : MonoBehaviour
{
    //public InputField immatriculationToTest;

    string getURL = "https://m.paruvendu.fr/fiches-techniques-auto/";

   public void OnButtonSearchCar()
    {
        StartCoroutine(LoadFirstPage());
    }

    IEnumerator LoadFirstPage()
    {
        UnityWebRequest www = UnityWebRequest.Get(getURL);

        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            print(www.downloadHandler.text);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
