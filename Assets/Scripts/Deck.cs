using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    
    public List<Cards.CardData> cards;
    public GameObject cardPrefab;
    // Start is called before the first frame update
    void Awake()
    {
        cards = new List<Cards.CardData>();
        for (int i = 0; i < 6; i++) {
            cards.Add(Cards.cards["Traveler"]["shot"]);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
