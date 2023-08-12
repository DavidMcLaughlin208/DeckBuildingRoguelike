using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrawPile : MonoBehaviour
{
    public TextMeshProUGUI drawText; 
    public List<Cards.CardData> cards = new List<Cards.CardData>();
    public CombatManager cm;
    public GameObject cardPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (drawText != null && cards != null) { 
            drawText.text = cards.Count.ToString();
        }
    }

    public Card Draw()
    {   
        if (cards.Count > 0) {
            Cards.CardData drawnCard = cards[0];
            cards.RemoveAt(0);
            Card newCard = Instantiate(cardPrefab).GetComponent<Card>();
            newCard.SetData(drawnCard);
            newCard.transform.position = transform.position;

            return newCard.GetComponent<Card>();
        }
        return null;
    }

    public void SetCards(List<Cards.CardData> cards) {
        this.cards = cards;
    }

    public void Shuffle()
    {
        for (int i = 0; i < cards.Count; i++) 
        {
            Cards.CardData temp = cards[i];
            int rand = Random.Range(i, cards.Count);
            cards[i] = cards[rand];
            cards[rand] = temp;
        }
    }

    
}
