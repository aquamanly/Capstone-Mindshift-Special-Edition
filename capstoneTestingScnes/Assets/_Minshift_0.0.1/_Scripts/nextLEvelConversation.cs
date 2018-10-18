using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class nextLEvelConversation : MonoBehaviour {

    public Button[] choices;
    public string NextLevelName;

	// Use this for initialization
	void Start () {
        choices = Button.FindObjectsOfType<Button>();
	}


    public void LoadLvlNow() {
        LoadALevelOFYourChoice(NextLevelName);
    }

    public void LoadALevelOFYourChoice(string level) {
        SceneManager.LoadSceneAsync(level, LoadSceneMode.Additive);
        
    }
    public void UnloadLvl(string level) {
        SceneManager.UnloadSceneAsync(level);
    }



    public void ButtonOfChoices(int x) {
        switch (x)
        {
            case 1:
                Debug.Log("Anger");
                break;
            case 2:
                Debug.Log("Mild");
                break;
            case 3:
                Debug.Log("Shy");
                break;
            case 4:
                Debug.Log("Nothing");
                break;
            default:
                break;
        }
    }
}
