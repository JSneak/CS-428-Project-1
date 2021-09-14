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

    public string[] eightBallQuotes = new string[] { "It is Certain", "It is decidely so", "Without a doubt", "Yes definitely", "You may rely on it", "As I see it, yes.", "Most likely", "Outlook good", "Reply hazy, try again", "Ask again later", "Better not tell you now", "Don't count on it", "My reply is no", "Very doubtful", "Cannot predict now", "Concentrate and ask again", "Yes", "Signs point to yes", "My sources say no","Outlook not so good", "Very doubtful" };

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
        //var xPos = UnityEditor.TransformUtils.GetInspectorRotation(KnickKnackObject.transform).x;
        var xPos = getEditorNumbers();
        Debug.Log(":\nReceived: " + xPos);

        /* If Rotation of X is between -20 to 0 or 0 to 20, then it is sitting */

        /* If Rotation of X is between 170 to 180 or -180 to -170 */

        if ( (xPos < 20 && xPos > 0) || (xPos > -20 && xPos < 0 ) ) 
        {
            /* Cube is in sitting position */
            if(hasBeenFlipped == true)
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

    float getEditorNumbers()
    {
        Vector3 angle = KnickKnackObject.transform.eulerAngles;
        float x = angle.x;
        float y = angle.y;
        float z = angle.z;

        if (Vector3.Dot(transform.up, Vector3.up) >= 0f)
        {
            if (angle.x >= 0f && angle.x <= 90f)
            {
                x = angle.x;
            }
            if (angle.x >= 270f && angle.x <= 360f)
            {
                x = angle.x - 360f;
            }
        }
        if (Vector3.Dot(transform.up, Vector3.up) < 0f)
        {
            if (angle.x >= 0f && angle.x <= 90f)
            {
                x = 180 - angle.x;
            }
            if (angle.x >= 270f && angle.x <= 360f)
            {
                x = 180 - angle.x;
            }
        }

        if (angle.y > 180)
        {
            y = angle.y - 360f;
        }

        if (angle.z > 180)
        {
            z = angle.z - 360f;
        }

        Debug.Log(angle + " :::: " + Mathf.Round(x) + " , " + Mathf.Round(y) + " , " + Mathf.Round(z));
        return Mathf.Round(x);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
