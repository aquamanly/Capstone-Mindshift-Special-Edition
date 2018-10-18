using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heroes : MonoBehaviour
{

    public int hp;
    public bool invulnerable = false;
    public int spd;
    private bool buttonClicked;
    public GameObject villain;
    public MyEnumType villain2;
    public GameObject gameController;
    public int ThisScene;
    public int NextScene;
    public Slider HP;
    public AudioSource music;
    public int LoseScene;
    void Awake()
    {
        HP.value = hp;
        villain = GameObject.FindGameObjectWithTag("Villain");
        spd = Random.Range(1, 20);
        villain2 = GameObject.FindGameObjectWithTag("Villain").GetComponent<enemy>().dropdown;
        music = GameObject.FindGameObjectWithTag("soundOfWar").GetComponent<AudioSource>();
    }

     void Start()
    {
        HP.value = hp;
    }

    public void attack(int X)
    {
        if (villain.GetComponent<enemy>().invulnerable == false)
        {

            if (X >= 1)
            {
                villain.GetComponent<enemy>().hp = villain.GetComponent<enemy>().hp - 2;
                villain.GetComponent<enemy>().ControllHealthSlider(2);
                if (villain.GetComponent<enemy>().hp <= 0 && hp >=1)
                {
                    //give the influece to you
                    //I think this will happen first
                    GetComponent<addingInfluence>().ChangeInffluence();
                    gameController.GetComponent<Level1Class>().goStraightToLevel(NextScene);
                }
              

            }
            else
            {
                villain.GetComponent<enemy>().hp = villain.GetComponent<enemy>().hp - 1;
                villain.GetComponent<enemy>().ControllHealthSlider(1);
                if (villain.GetComponent<enemy>().hp <= 0)
                {
                    //give the influece to you
                    //I think this will happen first
                    GetComponent<addingInfluence>().ChangeInffluence();
                    gameController.GetComponent<Level1Class>().goStraightToLevel(NextScene);
                }
            }
        }
        else
        {
            villain.GetComponent<enemy>().invulnerable = false;
        }
    }



    public void defend()
    {
        this.invulnerable = true;
    }

    public void heroDefends()
    {
        buttonClicked = true;
        Debug.Log("You have clicked defend!");
        buttonClicked = false;
        defend();
        villain.GetComponent<enemy>().VillainDoesHisThing();

    }

    void Update()
    {
        HP.value = hp;
        //if (hp <= 1 && villain.GetComponent<enemy>().hp <1)
        //{
        //    Debug.Log("ENEMY HP DEAD");
        //    GetComponent<addingInfluence>().ChangeInffluence();
        //}
        if (hp <= 0 && villain.GetComponent<enemy>().hp > 1)
        {
            //GetComponent<addingInfluence>().ChangeInffluence();
            gameController.GetComponent<Level1Class>().goStraightToLevel(LoseScene);
        }
        //else if (hp <= 0 && villain.GetComponent<enemy>().hp < 1) {
        //    GetComponent<addingInfluence>().ChangeInffluence();
        //    gameController.GetComponent<Level1Class>().goStraightToLevel(LoseScene);
        //}
    }

    public void Ilose() {
        gameController.GetComponent<Level1Class>().goStraightToLevel(LoseScene);
    }

    public void ControllHealthSlider(int x)
    {
        HP.value -= x;
    }

    public void heroAttacks()
    {
        Debug.Log("red");
        buttonClicked = true;
        Debug.Log("You have clicked red!");
        buttonClicked = false;
        villain.GetComponent<enemy>().HP.value = villain.GetComponent<enemy>().hp;
        if (villain2 == MyEnumType.BOSSY)
        {
            attack(1);
            
            music.clip = music.GetComponent<audioPocket>().SoundsOfWar[4];
            music.Play();
        }
        else
        {
            attack(0);
            
            music.clip = music.GetComponent<audioPocket>().SoundsOfWar[1];
            music.Play();
        }
        //if (villain.GetComponent<enemy>().hp <= 0)
        //{
        //    GetComponent<addingInfluence>().ChangeInffluence();
        //    gameController.GetComponent<Level1Class>().goStraightToLevel(NextScene);
        //}
        villain.GetComponent<textboxDialogueDad>().NewDialogueBubbles(1);
 
        villain.GetComponent<enemy>().VillainDoesHisThing();

    }

    public void heroBlue()
    {
        Debug.Log("blue");
        buttonClicked = true;
        Debug.Log("You have clicked blue!");
        buttonClicked = false;
        villain.GetComponent<enemy>().HP.value = villain.GetComponent<enemy>().hp;
        if (villain2 == MyEnumType.PASSIVE)
        {
            attack(1);
            //villain.GetComponent<enemy>().ControllHealthSlider(2);
            music.clip = music.GetComponent<audioPocket>().SoundsOfWar[4];
            music.Play();
        }
        else
        {
            attack(0);
            //villain.GetComponent<enemy>().ControllHealthSlider(1);
            music.clip = music.GetComponent<audioPocket>().SoundsOfWar[1];
            music.Play();
        }
        //if (villain.GetComponent<enemy>().hp <= 0)
        //{
        //    //give the influece to you
        //    //I think this will happen first
        //    GetComponent<addingInfluence>().ChangeInffluence();
        //    gameController.GetComponent<Level1Class>().goStraightToLevel(NextScene);
        //}
        villain.GetComponent<textboxDialogueDad>().NewDialogueBubbles(2);
        villain.GetComponent<enemy>().VillainDoesHisThing();
    }

    public void heroYellow()
    {
        Debug.Log("yellow");
        buttonClicked = true;
        Debug.Log("You have clicked yellow!");
        buttonClicked = false;
        villain.GetComponent<enemy>().HP.value = villain.GetComponent<enemy>().hp;
        if (villain2 == MyEnumType.STERN)
        {
            attack(1);
            //villain.GetComponent<enemy>().ControllHealthSlider(2);
            music.clip = music.GetComponent<audioPocket>().SoundsOfWar[4];
            music.Play();
        }
        else
        {
            attack(0);
            //villain.GetComponent<enemy>().ControllHealthSlider(1);
            music.clip = music.GetComponent<audioPocket>().SoundsOfWar[1];
            music.Play();
        }
        //if (villain.GetComponent<enemy>().hp <= 0)
        //{
        //    //give the influece to you
        //    //I think this will happen first
        //    GetComponent<addingInfluence>().ChangeInffluence();
        //    gameController.GetComponent<Level1Class>().goStraightToLevel(NextScene);
        //}
        villain.GetComponent<textboxDialogueDad>().NewDialogueBubbles(3);
        villain.GetComponent<enemy>().VillainDoesHisThing();
    }
}
