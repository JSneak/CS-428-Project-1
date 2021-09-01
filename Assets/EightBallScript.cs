using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EightBallScript : MonoBehaviour
{

    public GameObject Magic8TextObject;
    public GameObject KnickKnackObject;

    // Start is called before the first frame update
    void Start()
    {

        InvokeRepeating("keepTrackOfPosition", 2f, 1f);

    }

    void keepTrackOfPosition()
    {
        Debug.Log(":\nReceived: " + KnickKnackObject.transform.rotation.x);
        if(KnickKnackObject.transform.rotation.x)
        Magic8TextObject.GetComponent<TextMeshPro>().text = "Wow";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
