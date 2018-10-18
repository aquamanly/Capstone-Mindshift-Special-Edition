using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imageOfInfluence : MonoBehaviour {


    public Sprite[] InfluencePics;
    public GameObject MainInfluenceHub;
    public string TheEnemysName;
    
	// Use this for initialization
	void Start () {
        MainInfluenceHub = GameObject.FindGameObjectWithTag("GameController");
        TheEnemysName = GameObject.FindGameObjectWithTag("Villain").GetComponent<enemy>().MyPersonalName;
       

        switch (TheEnemysName)
        {
            case "Mom":
                if (MainInfluenceHub.GetComponent<NewGame>().momInfluence)
                {
                    this.gameObject.GetComponent<Image>().sprite = InfluencePics[1];
                }
                else { gameObject.GetComponent<Image>().sprite = InfluencePics[0]; }
                break;
            case "Salesman":
                if (MainInfluenceHub.GetComponent<NewGame>().salesmanInfluence)
                {
                    this.gameObject.GetComponent<Image>().sprite = InfluencePics[1];
                }
                else { gameObject.GetComponent<Image>().sprite = InfluencePics[0]; }
                break;
           
            default:
                gameObject.GetComponent<Image>().sprite = InfluencePics[0];
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
