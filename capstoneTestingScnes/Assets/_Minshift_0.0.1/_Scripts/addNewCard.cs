using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addNewCard : MonoBehaviour
{


    public GameObject daCard;
    public GameObject TheHand;
    public Button yourButton;
    public bool IveBeenPlucked = false;
    public GameObject thePluckedChecker;

    void Start()
    {
        thePluckedChecker = GameObject.FindGameObjectWithTag("deck1");
        Button btn = yourButton.GetComponent<Button>();

        if (thePluckedChecker.GetComponent<addNewCard>().IveBeenPlucked != true)
        {
            btn.onClick.AddListener(BtnOnClick);
            btn.onClick.AddListener(TaskOnClick);

            
        }
        else if (thePluckedChecker.GetComponent<addNewCard>().IveBeenPlucked == true)
        {
            
        }
    }


    public void BtnOnClick()
    {
        yourButton.GetComponent<Button>().interactable = false;
    }
    void TaskOnClick()
    {
        Debug.Log("You have clicked the button!");
        Instantiate(daCard, TheHand.transform);
        IveBeenPlucked = true;
    }

    public void Actions()
    {



    }

}
