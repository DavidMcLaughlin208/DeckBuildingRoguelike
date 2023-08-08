using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    
    public List<Card> cards;
    public GameObject cardPrefab;
    // Start is called before the first frame update
    void Awake()
    {
        cards = new List<Card>(cards);
        for (int i = 0; i < 6; i++) {
            GameObject newCard = Instantiate(cardPrefab);
            newCard.SetActive(false);
            cards.Add(newCard.GetComponent<Card>());
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
