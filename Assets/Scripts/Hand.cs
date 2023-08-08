using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public DrawPile drawPile;
    public DiscardPile discardPile;
    public List<Card> cards;
    public GameObject cardPrefab;

    // Start is called before the first frame update
    void Start()
    {
        cardPrefab = Resources.Load<GameObject>("Prefabs/Card");
        
    }

    private void HandSizeChanged()
    {
        float width = cardPrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        float buffer = 0.02f;
        float cardsContainerSize = cards.Count * (width + buffer);
        float sizePerCard = cardsContainerSize / cards.Count;
        for (int i = 0; i < cards.Count; i++)
        {
            Card card = cards[i];
            card.desiredPos = new Vector2(transform.position.x - (cardsContainerSize / 2) + sizePerCard * i, transform.position.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Draw();
        Draw();
        Draw();
        Draw();
    }

    public void Discard(Card toDiscard)
    {
        toDiscard.desiredPos = discardPile.transform.position;
        cards.Remove(toDiscard);
        HandSizeChanged(); 
    }

    void Draw()
    {
        Card newCard = drawPile.Draw();
        if (newCard != null) {
            cards.Add(newCard);
            HandSizeChanged();    
        }
    }

}
