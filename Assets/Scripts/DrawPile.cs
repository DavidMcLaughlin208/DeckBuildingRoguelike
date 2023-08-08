using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrawPile : MonoBehaviour
{
    public TextMeshProUGUI drawText; 
    public List<Card> cards;
    public CombatManager cm;
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
            Card drawnCard = cards[0];
            cards.RemoveAt(0);
            drawnCard.gameObject.SetActive(true);
            drawnCard.transform.position = transform.position;
            return drawnCard;
        }
        return null;
    }

    public void SetCards(List<Card> cards) {
        this.cards = cards;
    }

    public void Shuffle()
    {
        for (int i = 0; i < cards.Count; i++) 
        {
            Card temp = cards[i];
            int rand = Random.Range(i, cards.Count);
            cards[i] = cards[rand];
            cards[rand] = temp;
        }
    }

    
}
