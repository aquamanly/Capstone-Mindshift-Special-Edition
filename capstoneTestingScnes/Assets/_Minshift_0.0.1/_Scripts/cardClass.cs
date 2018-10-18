using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum cardEnum
{
    AGRESSIVE,
    WITHDRAWN,
    KIND
}

public class cardClass : MonoBehaviour
{

    public int numberOfCards;
    public cardEnum CardType;


    void Awake()
    {

        this.GetComponent<cardClass>().CardType = (cardEnum)UnityEngine.Random.Range(0, 3);
        
    }
    internal void subtractACard()
    {
        numberOfCards -= 1;
      
    }


    public cardEnum pickAnEnum(cardEnum theOne)
    {
        Array values = Enum.GetValues(typeof(cardEnum));
        System.Random random = new System.Random();

        theOne =
        (cardEnum)values.GetValue(random.Next(values.Length));

        return theOne;
    }
		

}
