using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand : MonoBehaviour {
	public GameObject[] cardHand;
    private int x;

    // Use this for initialization
    void Start () {
		cardHand = GameObject.FindGameObjectsWithTag("hand");
		foreach (GameObject item in cardHand)
		{
			
			item.transform.Translate(x,0,0);
			x++;
			x++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
