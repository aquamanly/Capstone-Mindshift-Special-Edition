using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadLevel : MonoBehaviour
{

    public string villainName;
    //public int villainHP;
    public bool vaillainBool;
    public int decisionPoint;
    public Scene[] listOfScenes = new Scene[2];
    //public Button rightButton;
    public bool OptionsPicked;
    public int anotherOption;
    public bool Influence;
    public bool playerDefeated;
    public bool villainDefeated;
    public String LevelToLoad;

    void Start()
    {
        SceneManager.LoadScene(LevelToLoad, LoadSceneMode.Additive);
        //Button btn = rightButton.GetComponent<Button>();
        //btn.onClick.AddListener(combatBoy);
        GameObject speach = GameObject.FindGameObjectWithTag("SpeachControl");
        //Influence = speach.GetComponent<dilaogue>().DadInfluence;

    }

    // Update is called once per frame
    void Update()
    {
        GameObject speach = GameObject.FindGameObjectWithTag("SpeachControl");
        if (speach != null)
        {
            Influence = speach.GetComponent<dilaogue>().DadInfluence;
            if (decisionPoint == 1 || decisionPoint == 2)
            {
                Debug.Log("dude");
                endConversation();
            }
        }

        GameObject villain = GameObject.FindGameObjectWithTag("Villain");
        GameObject heroGuy = GameObject.FindGameObjectWithTag("Hero");
        if (villain != null)
        {
            int villainHP = villain.GetComponent<enemy>().hp;
            int heroeHP = heroGuy.GetComponent<Heroes>().hp;
            if (villainHP <=0)
            {
                Debug.Log("What, oh no... I'm dead!");
                endCombatBoy();
            } else if (heroeHP <= 0)
            {
                Debug.Log("What, oh no... I'm dead!");
                endCombatBoyLose();
            }
        }

        //combatBoy();
        talkinMoment();
        Scene currentSceneWereIn = SceneManager.GetActiveScene();
        Debug.Log(currentSceneWereIn.ToString());
        //GameObject speach = GameObject.FindGameObjectWithTag("SpeachControl");
        //decisionPoint = speach.GetComponent<dilaogue>().num;


        if (playerDefeated)
        {
            endCombatBoy();
        }
        else if (villainDefeated)
        {
            endCombatBoy();
        }

        Debug.Log("dude6");
        GameObject villain2 = GameObject.FindGameObjectWithTag("Villain");

    }

    private void talkinMoment()
    {
        string level = SceneManager.GetSceneAt(1).ToString();
        Debug.Log("dude1");
        GameObject speach = GameObject.FindGameObjectWithTag("SpeachControl");
        GameObject villainsBody = GameObject.FindGameObjectWithTag("Villain");


        if (speach != null)
        {
            decisionPoint = speach.GetComponent<dilaogue>().numChange;
            Influence = speach.GetComponent<dilaogue>().DadInfluence;

            Debug.Log("dude2");

            if (decisionPoint == 1 || decisionPoint == 2)
            {
                Debug.Log("dude3");
                //combatBoy();

            }
        }


    }

    void endCombatBoy()
    {
        Debug.Log("dude4");
        SceneManager.UnloadSceneAsync("_SCENE_");
        SceneManager.LoadScene("YouWin", LoadSceneMode.Additive);
    }
       void endCombatBoyLose()
    {
        Debug.Log("dude4");
        SceneManager.UnloadSceneAsync("_SCENE_");
        SceneManager.LoadScene("YouLose", LoadSceneMode.Additive);
    }
    void endConversation()
    {
        Debug.Log("dude5");

        SceneManager.UnloadSceneAsync("conversations 1");
        SceneManager.LoadScene("_SCENE_", LoadSceneMode.Additive);
        Time.timeScale = 1;

    }


    void combatBoy()
    {
        string level = SceneManager.GetSceneAt(0).ToString();
        Debug.Log("dude6");
        GameObject heroes = GameObject.FindGameObjectWithTag("Hero");
        if (heroes != null)
        {
            villainName = heroes.name;
            Debug.Log("dude7");

        }
    }
}
