using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        float width = cardPrefab.GetComponent<RectTransform>().sizeDelta.x;
        float buffer = 0.02f;
        float cardsContainerSize = cards.Count * (width + buffer);
        float sizePerCard = cardsContainerSize / cards.Count;
        for (int i = 0; i < cards.Count; i++)
        {
            Card card = cards[i];
            card.SetDesiredPos(new Vector3(transform.position.x - (cardsContainerSize / 2) + sizePerCard * i, transform.position.y, 1), null);
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
        toDiscard.grabbed = false;
        toDiscard.SetDesiredPos(discardPile.transform.position, () => Destroy(toDiscard.gameObject));
        cards.Remove(toDiscard);
        discardPile.Discard(toDiscard);
        HandSizeChanged(); 
    }

    void Draw()
    {
        Card newCard = drawPile.Draw();
        if (newCard != null) {
            cards.Add(newCard);
            newCard.hand = this;
            newCard.transform.SetParent(transform);
            newCard.transform.localScale = new Vector3(1,1,1);
            HandSizeChanged();
        }
    }

}
