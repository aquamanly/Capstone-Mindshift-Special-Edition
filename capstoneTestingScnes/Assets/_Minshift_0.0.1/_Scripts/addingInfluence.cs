using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addingInfluence : MonoBehaviour
{


    public GameObject TheInfluence;
    public bool DadisInfluemced = true;
    public string InfluenceYouStandToGain;
    public bool Befriended;
    // Use this for initialization
    void Start()
    {
        TheInfluence = GameObject.FindGameObjectWithTag("GameController");
        //TheInfluence.GetComponent<NewGame>().dadInfluence = true;
        //the following code inly proves that we're 
        //communicating with the Over_SCene
        //it works, but I commented it out
        //DadisInfluemced = TheInfluence.GetComponent<NewGame>().dadInfluence;
    }

    void Update() {
        if (Befriended)
        {
            TheInfluence.GetComponent<NewGame>().salesmanInfluence = true;
            TheInfluence.GetComponent<NewGame>().girlInfluence = true;
        }
    }


    public void ChangeInffluence()
    {
        Debug.Log("I'm workin here!");
        switch (InfluenceYouStandToGain)
        {
            case "Dad":
                TheInfluence.GetComponent<NewGame>().dadInfluence = true;
                Debug.Log("DaddyInfluences");
                break;
            case "Mom":
                TheInfluence.GetComponent<NewGame>().momInfluence = true;
                Debug.Log("Mom Influences");
                break;
            case "Salesman":
                TheInfluence.GetComponent<NewGame>().salesmanInfluence = true;
                Debug.Log("Sales Influences");
                break;
            default:
                Debug.Log("No Influences");
                break;
        }
    }
}
