using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TextControllerPArt2 : MonoBehaviour {

	//Setting up animation for dad
	Animator dadState;

	public int counup=0;


    public Text textBox;
	public int TheNameOfTheNextLevel;
    

	const int Normal = 0;
	const int Happy = 1;
	const int Sad = 2;
	const int Angry = 3;
    


    public int currentlyDisplayingText = 0;
    public string[] goatText = new string[] {
        "1. Laik's super awesome custom typewriter script",
        "2. You can click to skip to the next text",
        "3.All text is stored in a single string array",
        "4. Ok, now we can continue",
        "5. End Kappa"
    };


    void Awake()
    {
		//Look at the animator
		dadState = this.GetComponent<Animator>();
        StartCoroutine(AnimateText());
    }



	public void countingUP(){
		counup++;
	}

    //This is a function for a button you press to skip to the next text
    public void SkipToNextText()
    {
        StopAllCoroutines();
        currentlyDisplayingText++;
		//Top text seems very important
        //If we've reached the end of the array, do anything you want. I just restart the example text
        if (currentlyDisplayingText > goatText.Length)
        {
            //currentlyDisplayingText = 0;
            Debug.Log("I'm done");
			SceneManager.LoadScene(TheNameOfTheNextLevel, LoadSceneMode.Single);
        }
        StartCoroutine(AnimateText());

		//Logically, make the sprite change depending on which element #


    }
    
    //Note that the speed you want the typewriter effect to be going at is the yield waitforseconds
    //(in my case it's 1 letter for every      0.03 seconds, replace this with a public float if you want to experiment with speed in from the editor)
    IEnumerator AnimateText()
    {

        for (int i = 0; i < (goatText[currentlyDisplayingText].Length + 1); i++)
        {
            textBox.text = goatText[currentlyDisplayingText].Substring(0, i);
            //goatText[i].text = goatText[currentlyDisplayingText].Substring(0, i);
            yield return new WaitForSeconds(.03f);
        }

		Debug.Log ("This is working " + goatText [2]);
    }
}