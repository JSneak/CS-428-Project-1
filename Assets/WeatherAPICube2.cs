using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

public class WeatherAPICube2 : MonoBehaviour
{

    public GameObject weatherTextObject;
    // add your personal API key after APPID= and before &units= 
    string url = "http://api.openweathermap.org/data/2.5/weather?lat=37.76653935415943&lon=-122.48634762042931&APPID=10f0f2739199bdfca8d826a6307db86f&units=metric";

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GetDataFromWeb", 2f, 600f);
    }
    void GetDataFromWeb()
    {

        StartCoroutine(GetRequest(url));
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();


            if (webRequest.isNetworkError)
            {
                Debug.Log(": Error: " + webRequest.error);
            }
            else
            {
                // print out the weather data to make sure it makes sense
                Debug.Log(":\nReceived: " + webRequest.downloadHandler.text);


                // grab the current temperature and simplify it if needed
                int startTemp = webRequest.downloadHandler.text.IndexOf("temp", 0);
                int endTemp = webRequest.downloadHandler.text.IndexOf(",", startTemp);
                double tempF = float.Parse(webRequest.downloadHandler.text.Substring(startTemp + 6, (endTemp - startTemp - 6)));
                int easyTempF = Mathf.RoundToInt((float)tempF);
                //Debug.Log ("integer temperature is " + easyTempF.ToString());
                int startConditions = webRequest.downloadHandler.text.IndexOf("main", 0);
                int endConditions = webRequest.downloadHandler.text.IndexOf(",", startConditions);
                string conditions = webRequest.downloadHandler.text.Substring(startConditions + 7, (endConditions - startConditions - 8));
                //Debug.Log(conditions);

                weatherTextObject.GetComponent<TextMeshPro>().text = "" + easyTempF.ToString() + "°C\n" + conditions;
            }
        }
    }
}
