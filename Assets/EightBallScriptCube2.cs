using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class EightBallScriptCube2 : MonoBehaviour
{

    public GameObject Magic8TextObject;
    public GameObject KnickKnackObject;

    private AudioSource source;

    public bool hasBeenFlipped;

    public string[] eightBallQuotes = new string[] { "What did you just say?", "That's epic", "👍", "👎", "uuhhhh", "The money is calling", "Something bad is going to happen", "The future looks grim", "Sometimes I get it I don't even want it", "idk man", "it's a hard no" };

    // Start is called before the first frame update
    void Start()
    {

        source = GetComponent<AudioSource>();
        Magic8TextObject.GetComponent<TextMeshPro>().text = "Flip Me";
        hasBeenFlipped = false;
        InvokeRepeating("keepTrackOfPosition", 1f, 1f);

    }

    void keepTrackOfPosition()
    {
        var xPos = UnityEditor.TransformUtils.GetInspectorRotation(KnickKnackObject.transform).x;
        //Debug.Log(":\nReceived: " + xPos);

        /* If Rotation of X is between -20 to 0 or 0 to 20, then it is sitting */

        /* If Rotation of X is between 170 to 180 or -180 to -170 */

        if ((xPos < 20 && xPos > 0) || (xPos > -20 && xPos < 0))
        {
            /* Cube is in sitting position */
            if (hasBeenFlipped == true)
            {
                /* Choose a random classic saying */
                int index = Random.Range(0, eightBallQuotes.Length);

                /* Play a sound effect */
                source.Play();
                /* Set hasBeenFlipped to false */
                hasBeenFlipped = false;

                /* Debug Statement */
                //Debug.Log(":\nQuote Position: " + index);
                Magic8TextObject.GetComponent<TextMeshPro>().text = eightBallQuotes[index];
            }
        }

        if ((xPos < 180 && xPos > 170) || (xPos > -180 && xPos < -170))
        {
            /* Cube is upside down */
            hasBeenFlipped = true;

            /* Debug Statement */
            //Magic8TextObject.GetComponent<TextMeshPro>().text = "Flipped";
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
