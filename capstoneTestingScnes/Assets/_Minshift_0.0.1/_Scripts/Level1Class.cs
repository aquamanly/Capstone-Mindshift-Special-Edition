using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Class : MonoBehaviour
{

    public int numberOFIncriments;
    public GameObject theGameController;
    public int storyBeats;
    public int ThisLevelNumber;
    public int NextLevelNumber;
    public bool byPressOrByLevel;
    public bool EndGame;
    public bool IsThisScn15;
    public int ScnIfIHaveInfluence;
    public int ScnIfIDontHaveInfluence;

    // Use this for initialization
    void Start()
    {
        theGameController = GameObject.FindGameObjectWithTag("GameController");
    }

    // Update is called once per frame
    void Update()
    {

        if (numberOFIncriments == storyBeats)
        {
            if (byPressOrByLevel)
            {
                if (EndGame)
                {
                    EndGameNow();
                }
                else
                {
                    theGameController.GetComponent<NewGame>().NextLevel();
                }
            }
            
            else if (IsThisScn15)
            {
                if (theGameController.GetComponent<NewGame>().salesmanInfluence)
                {
                    goStraightToLevel(ScnIfIHaveInfluence);
                }
                else
                {
                    //if influence isn't had
                    //go here
                    goStraightToLevel(ScnIfIDontHaveInfluence);
                }
                

           
            }
            else
            {
                goStraightToLevel(NextLevelNumber);
            }
        }


    }

    public void addUpp()
    {
        numberOFIncriments++;
    }

    public void goStraightToLevel(int x)
    {

        theGameController.GetComponent<NewGame>().NextLevelConversation(x);
        theGameController.GetComponent<NewGame>().i = x;

    }

    public void GetStraightToTheNextLevel()
    {
        theGameController.GetComponent<NewGame>().NextLevel();
    }

   

    public void EndGameNow()
    {
        Application.Quit();
    }

}
