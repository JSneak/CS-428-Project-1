using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EightBallScript : MonoBehaviour
{

    public GameObject Magic8TextObject;

    // Start is called before the first frame update
    void Start()
    {
        Magic8TextObject.GetComponent<TextMeshPro>().text = "Wow";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
