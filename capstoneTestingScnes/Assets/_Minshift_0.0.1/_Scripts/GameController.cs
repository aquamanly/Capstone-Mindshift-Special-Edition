using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    
	public int[] scenes;
    public int i;



	// Use this for initialization
	void Start () {
        i = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NextLevel() {
        i++;
        SceneManager.LoadSceneAsync(scenes[i]);
      
        SceneManager.UnloadSceneAsync(scenes[i - 1]);
    }


}
