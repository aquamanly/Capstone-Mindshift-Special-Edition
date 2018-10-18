using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeIN : MonoBehaviour
{
    public Transform startMarker;
    public Transform endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;
    public Color reset;
    public Color halfReset;
    private float T;
    public float minimum = -1.0F;
    public float maximum = 1.0F;

    // starting value for the Lerp
    static float t = 0.0f;
    //public Color lerpedColor = Color.white;

    private void OnMouseEnter()
    {
    }
    public void OnMouseOver()
    {
        // If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
        //    lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
        //lerpedColor = Color.Lerp(this.GetComponent<SpriteRenderer>().color, Color.blue, Mathf.PingPong(Time.time, 1));
        //this.GetComponent<SpriteRenderer>().color = Color.Lerp(reset, halfReset, Mathf.Lerp(minimum, maximum, t));
        this.GetComponent<SpriteRenderer>().color = Color.Lerp(this.GetComponent<SpriteRenderer>().color, Color.blue, Mathf.PingPong(Time.time, 1));

    }


    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
        // lerpedColor = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
        this.GetComponent<SpriteRenderer>().color = Color.Lerp(halfReset, reset, Mathf.Lerp(0, 1, 3));
    }


    void Start()
    {
        //reset= this.GetComponent<SpriteRenderer>().color;
        reset.a = 0f;
        halfReset = this.GetComponent<SpriteRenderer>().color;
        halfReset.a = 0.5f;
        //startTime = Time.time;
        // journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }
    void Update()
    {
        T += .05f * Time.deltaTime;
        if (T > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            T = 0.0f;
        }
    }
}
