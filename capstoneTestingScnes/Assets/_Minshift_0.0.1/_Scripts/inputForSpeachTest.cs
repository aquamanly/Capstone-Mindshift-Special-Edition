using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputForSpeachTest : MonoBehaviour {

    public GameObject texCon;
    public TextControllerPArt2 texConText;
    public Vector3 bruce;
    // Use this for initialization
    void Start () {
        //texCon = new GameObject();
        texConText = new TextControllerPArt2();
  
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.A))
        {
            texCon.GetComponent<TextControllerPArt2>().SkipToNextText();
            Debug.Log("This works");
            bruce = texCon.GetComponent<Transform>().position;

        }
    }
}
