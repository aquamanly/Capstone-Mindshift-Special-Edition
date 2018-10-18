using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tuner : MonoBehaviour
{

    public int heroesSpd;
    public int villainsSpd;
    public bool heroFirst;

    public bool buttonClicked;
    public Button HeroAttack;

    public Button yellow;
    public Button blue;
    public Button HeroDeffense;
    public GameObject buttonHome;

    public GameObject villain;
    public GameObject hero;


    void Awake()
    {
        villain = GameObject.FindGameObjectWithTag("Villain");
        hero = GameObject.FindGameObjectWithTag("Hero");
        villainsSpd = villain.GetComponent<enemy>().spd;
        heroesSpd = hero.GetComponent<Heroes>().spd;

    }
    void Start()
    {
        buttonClicked = false;


        Button atkButn = HeroAttack.GetComponent<Button>();
        atkButn.onClick.AddListener(hero.GetComponent<Heroes>().heroAttacks);

        Button defButn = HeroDeffense.GetComponent<Button>();
        defButn.onClick.AddListener(hero.GetComponent<Heroes>().heroDefends);

        Button ylwButn = yellow.GetComponent<Button>();
        ylwButn.onClick.AddListener(hero.GetComponent<Heroes>().heroYellow);

        Button bluButn = blue.GetComponent<Button>();
        bluButn.onClick.AddListener(hero.GetComponent<Heroes>().heroBlue);
        
        if (heroesSpd > villainsSpd)
        {
            buttonHome.SetActive(true);
            Debug.Log("The hero goes first");
            heroFirst = true;
        }
        else
        {
            buttonHome.SetActive(true);
            Debug.Log("the villain goes first");
            heroFirst = false;
            villain.GetComponent<enemy>().VillainDoesHisThing();
            buttonHome.SetActive(false);
        }
    }
}