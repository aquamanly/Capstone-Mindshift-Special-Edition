using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class dilaogue : MonoBehaviour
{
    //public string words = "abcdef";
    //public string[] a = words.Select(c => c.ToString()).ToArray();

    public string[] first;
    //public string[] second;
    //public string[] third;
    public Text dialogue;
    public string fullsentence;
    int character = 0;
    public string[] script;
    public Button nextText;
    public int num = 0;

    public Button OptionA;
    public Button OptionB;
    public Button A;
    public Button B;
    public int numChange;

    public bool DadInfluence;
    // Use this for initialization
    void Start()
    {


        Button next = nextText.GetComponent<Button>();
        next.onClick.AddListener(saythings);

        Button A = OptionA.GetComponent<Button>();

        Button B = OptionB.GetComponent<Button>();


        script = new string[] { "Are ", "Are you", "Are you Son, what are you doing?" };
        //saythings();
        Debug.Log("dang");
        if (num >= 3)
        {
            //Debug.Log("Live free!");
            A.onClick.AddListener(pickedA);
            B.onClick.AddListener(pickedB);
        }
        else
        {
            //Debug.Log("Live hhh!");
            A.onClick.AddListener(doNothing);
            B.onClick.AddListener(doNothing);
        }

    }

    private void doNothing()
    {
        throw new NotImplementedException();
    }

    void pickedB()
    {
        //Debug.Log("BBBB");
        numChange = 2;
        DadInfluence = true;

    }

    void pickedA()
    {

        //Debug.Log("AAAAA");
        numChange = 1;
        DadInfluence = false;
    }

    private void nextDialogueBox()
    {
        //b=script[0]++;
    }

 

    void saythings()
    {

        fullsentence = "";
        first = script[num].Select(converting => converting.ToString()).ToArray();
        Debug.Log(first);
        if (num <= 2)
        {
            StartCoroutine(WaitAndPrint(0.20f, first));
            num++;
        }


    }



    private IEnumerator WaitAndPrint(float waitTime, string[] wordy)
    {
        if (wordy.Length > character)
        {
            foreach (string item in wordy)
            {
                Debug.Log(wordy[character]);
                fullsentence += wordy[character];
                character+=1;
                yield return new WaitForSeconds(waitTime);
                dialogue.text = fullsentence;

            }

        }

    }
}