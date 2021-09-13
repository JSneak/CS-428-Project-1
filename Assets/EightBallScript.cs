using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EightBallScript : MonoBehaviour
{

    public GameObject Magic8TextObject;
    public GameObject KnickKnackObject;

    private AudioSource source;

    public bool hasBeenFlipped;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        Magic8TextObject.GetComponent<TextMeshPro>().text = "Sitting";
        hasBeenFlipped = false;
        InvokeRepeating("keepTrackOfPosition", 1f, 1f);

    }

    void keepTrackOfPosition()
    {
        var xPos = UnityEditor.TransformUtils.GetInspectorRotation(KnickKnackObject.transform).x;
        Debug.Log(":\nReceived: " + xPos);

        /* If Rotation of X is between -20 to 0 or 0 to 20, then it is sitting */

        /* If Rotation of X is between 170 to 180 or -180 to -170 */

        if( (xPos < 20 && xPos > 0) || (xPos > -20 && xPos < 0 ) ) 
        {
            /* Cube is in sitting position */
            if(hasBeenFlipped == true)
            {
                /* Choose a random classic saying */

                /* Play a sound effect */
                source.Play();
                /* Set hasBeenFlipped to false */
                hasBeenFlipped = false;

                /* Debug Statement */
                Magic8TextObject.GetComponent<TextMeshPro>().text = "Unflipped";
            }
        }

        if ((xPos < 180 && xPos > 170) || (xPos > -180 && xPos < -170))
        {
            /* Cube is upside down */
            hasBeenFlipped = true;

            /* Debug Statement */
            Magic8TextObject.GetComponent<TextMeshPro>().text = "Flipped";
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
