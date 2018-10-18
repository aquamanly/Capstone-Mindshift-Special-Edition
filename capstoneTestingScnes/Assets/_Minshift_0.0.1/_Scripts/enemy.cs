using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum MyEnumType
{
    STERN,
    BOSSY,
    PASSIVE
}
public class enemy : MonoBehaviour
{
    public string InfluenceYouGain;
    public int hp;
    public int spd;
    public int randomDecision;
    public bool invulnerable;
    //public GameObject theButtons;
    public GameObject theButtons2;
    public GameObject theButtons3;
    public GameObject theButtons4;
    public MyEnumType dropdown;
    public bool influenceToken;
    public GameObject theOtherScene;
    public string OtherSceneName;
    public GameObject Speachbox1;
    public GameObject Speachbox2;
    public GameObject Speachbox3;
    public Slider HP;
	public bool AmIInfluenced; 
	public string enemyNAME;
    public string MyPersonalName;


    void Awake()
    {
        HP.value = hp;
        Speachbox1.SetActive(false);
        Speachbox2.SetActive(false);
        Speachbox3.SetActive(false);
        //theButtons = GameObject.FindGameObjectWithTag("canvas");
        theButtons2 = GameObject.FindGameObjectWithTag("card3");
        theButtons3 = GameObject.FindGameObjectWithTag("card4");
        theButtons4 = GameObject.FindGameObjectWithTag("deck1");
        
		enemyNAME = this.gameObject.name;
		//AmIInfluenced =

		switch (MyPersonalName) {
		case "Mom":
			Debug.Log ("MOM IS INFLUENCED");
			AmIInfluenced = GameObject.FindGameObjectWithTag ("GameController").GetComponent<NewGame> ().momInfluence;
                if (AmIInfluenced == true)
                {
                    hp = 2;
                    HP.value = 2;
                }
                break;
            case "Salesman":
                Debug.Log("MOM IS INFLUENCED");
                AmIInfluenced = GameObject.FindGameObjectWithTag("GameController").GetComponent<NewGame>().salesmanInfluence;
                if (AmIInfluenced == true)
                {
                    hp = 2;
                    HP.value = 2;
                }
                break;
            
		default:
			break;
		}


        spd = Random.Range(1, 20);
		if (AmIInfluenced == true)
        {
            hp = 2;
            HP.value = 2;
        }
        else
        {
            hp = 5;
            HP.value = 5;
        }
        theOtherScene = GameObject.FindGameObjectWithTag("OverSceneController");
        OtherSceneName = theOtherScene.name;
        if (theOtherScene.GetComponent<loadLevel>().Influence)
        {

            hp = 5;
            Debug.Log("I have influence over the adult!");
            influenceToken = true;
        }
        else
        {
            hp = 10;
            Debug.Log("I FAILED! I dont have influence over the adult!");
            influenceToken = false;
        }
        Speachbox1.SetActive(false);
        Speachbox2.SetActive(false);
        Speachbox3.SetActive(false);
    }


    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        HP.value = hp;
        if (hp < 1)
        {
            Debug.Log("ENEMY HP DEAD");
            //GetComponent<addingInfluence>().ChangeInffluence();
            //this.gameObject.GetComponent<nextLEvelConversation>().LoadLvlNow();

        }

        //HP.value = hp;
    }



    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        HP.value = hp;
    }
    public void pickWhatYouWannaDo()
    {
        randomDecision = Random.Range(1, 3);
        switch (randomDecision)
        {
            case 1:
                Debug.Log("I attacked");
                attack();
                break;
            case 2:
                Debug.Log("I attacked harder");
                attackHarder();
                break;
            case 3:
                Debug.Log("I defended");
                defend();
                break;
            default:
                Debug.Log("I defaulted");
                break;
        }

    }

    public void defend()
    {
        this.invulnerable = true;
    }

    public void attack()
    {
        GameObject heroes = GameObject.FindGameObjectWithTag("Hero");
        if (heroes.GetComponent<Heroes>().invulnerable == false)
        {
            heroes.GetComponent<Heroes>().hp = heroes.GetComponent<Heroes>().hp - 1;
            heroes.GetComponent<Heroes>().ControllHealthSlider(1);
            if (heroes.GetComponent<Heroes>().hp <= 0)
            {
                heroes.GetComponent<Heroes>().Ilose();
            }


            //gameController.GetComponent<Level1Class>().goStraightToLevel(NextScene);


        }
        else
        {

            heroes.GetComponent<Heroes>().invulnerable = false;
        }
    }
    public void attackHarder()
    {
        GameObject heroes2 = GameObject.FindGameObjectWithTag("Hero");
        if (heroes2.GetComponent<Heroes>().invulnerable == false)
        {
            heroes2.GetComponent<Heroes>().hp = heroes2.GetComponent<Heroes>().hp - 2;
            heroes2.GetComponent<Heroes>().ControllHealthSlider(2);

        }
        else
        {

            heroes2.GetComponent<Heroes>().invulnerable = false;
        }
    }


    public void ControllHealthSlider(int x) {
        HP.value -= x;
    }
    public void VillainDoesHisThing()
    {
        StartCoroutine(WaitAndPrint(2));
        GameObject villainsMove = GameObject.FindGameObjectWithTag("Villain");
        //villainsMove.GetComponent<enemy>().attack();
        pickWhatYouWannaDo();
    }
    private IEnumerator WaitAndPrint(float waitTime)
    {

        //theButtons.SetActive(false);
        theButtons2.SetActive(false);
        //theButtons4.GetComponent<addNewCard>().IveBeenPlucked = false;

        //theButtons3.SetActive(false);
        theButtons3.SetActive(false);
     
        yield return new WaitForSeconds(waitTime);
        Speachbox1.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        Speachbox1.SetActive(false);
        Speachbox2.SetActive(true);
        yield return new WaitForSeconds(waitTime - 1.0f);
        Speachbox2.SetActive(false);
        Speachbox3.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        Speachbox3.SetActive(true);
        theButtons2.SetActive(true);
        theButtons3.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        Speachbox3.SetActive(false);
        theButtons4.GetComponent<addNewCard>().IveBeenPlucked = false;
        theButtons3.GetComponent<Button>().interactable = true;
    }
}
