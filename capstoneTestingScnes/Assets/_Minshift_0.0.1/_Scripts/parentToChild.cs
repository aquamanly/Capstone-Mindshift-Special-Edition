using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class parentToChild : MonoBehaviour
{
    public GameObject thisObject;
    public GameObject thisParentObject;


	public string[] agressiveStatements;
	public string[] kindStatements;
	public string[] withdrawnStatements;


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        thisObject = this.gameObject;
        thisParentObject = this.gameObject.transform.parent.gameObject;

		switch (thisParentObject.GetComponent<cardClass>().CardType)
		{
		case cardEnum.AGRESSIVE:
			Debug.Log("agressive card");
			//Text thetext = thisObject.GetComponent (typeof(Text)) as text
			thisObject.GetComponent<Text> ().text = agressiveStatements[ Random.Range (0, agressiveStatements.Length)];

			break;
		case cardEnum.KIND:
			Debug.Log ("kind card");
			thisObject.GetComponent<Text> ().text = kindStatements[ Random.Range (0, kindStatements.Length)];

			break;
		case cardEnum.WITHDRAWN:
			Debug.Log("withdrawn card");
			thisObject.GetComponent<Text> ().text = withdrawnStatements[ Random.Range (0, withdrawnStatements.Length)];
			break;
		default:
			break;
		}
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        switch (thisParentObject.GetComponent<cardClass>().CardType)
        {
            case cardEnum.AGRESSIVE:
                Debug.Log("agressive card");
				//Text thetext = thisObject.GetComponent (typeof(Text)) as text
				//thisObject.GetComponent<Text>().text = "agressive statement";

                break;
		case cardEnum.KIND:
			Debug.Log ("kind card");


                break;
            case cardEnum.WITHDRAWN:
                Debug.Log("withdrawn card");
			//thisObject.GetComponent<Text>().text = "withdrawn statement";
                break;
            default:
                break;
        }
    }
}

