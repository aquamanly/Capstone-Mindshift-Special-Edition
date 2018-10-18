using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deckAndHandManager : MonoBehaviour
{

    public GameObject cardPrefab;
    public List<GameObject> hand = new List<GameObject>();
    // Use this for initialization
    void Start()
    {
        int x = 0;
        for (int i = 0; i < 4; i++)
        {
            x++;

            cardPrefab = Instantiate(cardPrefab, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
            int choices = Random.Range(0, 3);
            switch (choices)
            {
                case 0:
                    cardPrefab.GetComponent<cardClass>().CardType = cardEnum.KIND;
                    ++x;
                    break;
                case 1:
                    cardPrefab.GetComponent<cardClass>().CardType = cardEnum.AGRESSIVE;
                    cardPrefab.name = x.ToString();
                    ++x;
                    break;
                case 2:
                    cardPrefab.GetComponent<cardClass>().CardType = cardEnum.WITHDRAWN;
                    cardPrefab.name = x.ToString();
                    ++x;
                    break;
                    //default:
            }
            hand.Add(cardPrefab);	//cardPrefab.GetComponent<cardClass>().CardType = cardPrefab.GetComponent<cardClass>().PickingARandomEnum();
        }

    }

}
