using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textboxDialogueDad : MonoBehaviour {

    public Text[] bossBattleScript = new Text[3];
    public string[] BluePhrases = new string[3];
    public string[] RedPhrases = new string[3];
    public string[] YellowPhrases = new string[3];

    public 

	// Use this for initialization
	void Start () {
        bossBattleScript[0] = GetComponent<enemy>().Speachbox1.GetComponentInChildren<Text>();
        bossBattleScript[1] = GetComponent<enemy>().Speachbox2.GetComponentInChildren<Text>();
        bossBattleScript[2] = GetComponent<enemy>().Speachbox3.GetComponentInChildren<Text>();
        NewDialogueBubbles(Random.Range(1,3));
    }
	


    public void NewDialogueBubbles(int numberForTextSelection) {
        switch (numberForTextSelection)
        {
            case 1:
                bossBattleScript[0].text = RedPhrases[0];
                bossBattleScript[1].text = RedPhrases[1];
                bossBattleScript[2].text = RedPhrases[2];
                break;
            case 2:
                bossBattleScript[0].text = BluePhrases[0];
                bossBattleScript[1].text = BluePhrases[1];
                bossBattleScript[2].text = BluePhrases[2];
                break;
            case 3:
                bossBattleScript[0].text = YellowPhrases[0];
                bossBattleScript[1].text = YellowPhrases[1];
                bossBattleScript[2].text = YellowPhrases[2];

                break;
            default:
                break;
        }

        
            
    }
}
