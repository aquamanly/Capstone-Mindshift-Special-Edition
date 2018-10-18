using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine;
using UnityEngine.UI;
public class cards : MonoBehaviour
{


    public Button blue;
	public Button[] aCard;
    public GameObject[] cardsInHand;

    public GameObject card;
    public int cardCount;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        card = GameObject.FindGameObjectWithTag("card");
        cardsInHand = GameObject.FindGameObjectsWithTag("hand");
        cardCount = card.GetComponent<cardClass>().numberOfCards;
//aCard = Button. FindGameObjectsWithTag("hand");
    }
    // Use this for initialization
    void Start()
    {
        //buttonClicked = false;
        foreach (GameObject item in cardsInHand)
        {
            item.GetComponent<Button>().IsActive().Equals(false);
			item.GetComponent<cardClass>().CardType = (cardEnum)Random.Range(0, 3);
        }
        //Button blue = GameObject.FindGameObjectWithTag("button").GetComponent<Button>();
        blue.onClick.AddListener(card.GetComponent<cardClass>().subtractACard);
		
    }

 
}
