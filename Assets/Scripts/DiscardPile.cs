using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiscardPile : MonoBehaviour
{
    public TextMeshProUGUI drawText; 
    public List<Card> cards = new List<Card>();
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

    public void Discard(Card card) {
        cards.Add(card);
    }
}
