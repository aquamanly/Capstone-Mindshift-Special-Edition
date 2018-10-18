﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showME : MonoBehaviour {


	public GameObject villain;

	// Use this for initialization
	void Start () {
		
		villain = GameObject.FindGameObjectWithTag ("Villain");
	}
	
	// Update is called once per frame
	void Update () {
		if (villain.GetComponent<enemy> ().invulnerable) {
			this.gameObject.GetComponent<Image> ().enabled = true;
		} else {
			this.gameObject.GetComponent<Image> ().enabled = false;
		}
	}
}
