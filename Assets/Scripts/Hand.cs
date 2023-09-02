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
    Card hoveredCard;

    // Start is called before the first frame update
    void Start()
    {
        cardPrefab = Resources.Load<GameObject>("Prefabs/Card");
        
    }

    private void HandSizeChanged()
    {
        UpdateCardPositions(2000);
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
        toDiscard.grabbable = false;
        toDiscard.SetDesiredPos(discardPile.transform.position, 2000, () => Destroy(toDiscard.gameObject));
        toDiscard.SetDesiredScale(new Vector3(0.6f,0.6f,1), 10, null);
        cards.Remove(toDiscard);
        discardPile.Discard(toDiscard);
        HandSizeChanged(); 
    }

    public void SetHoveredCard(Card card)
    {
        hoveredCard = card;
        UpdateCardPositions(500);
    }

    void UpdateCardPositions(float speed)
    {
        float width = cardPrefab.GetComponent<RectTransform>().sizeDelta.x;
        float buffer = 0.02f;
        float cardsContainerSize = cards.Count * (width + buffer);
        float sizePerCard = cardsContainerSize / cards.Count;
        for (int i = 0; i < cards.Count; i++)
        {
            Card card = cards[i];
            Vector3 newPos = new Vector3(transform.position.x - (cardsContainerSize / 2) + sizePerCard * i, transform.position.y, 1);
            if (hoveredCard && hoveredCard != card && !hoveredCard.grabbed)
            {
                int idx = cards.IndexOf(hoveredCard);
                Vector3 hoveredCardDesiredPos = new Vector3(transform.position.x - (cardsContainerSize / 2) + sizePerCard * idx, transform.position.y, 1);
                float dist = Vector3.Distance(newPos, hoveredCardDesiredPos);
                Vector3 dir = (newPos - hoveredCard.transform.position).normalized;
                newPos += Vector3.Scale(dir, new Vector3(7000/dist, 0, 0));
            }
            card.SetDesiredPos(newPos, speed, null);
        }

        if (hoveredCard != null)
        {
            hoveredCard.transform.SetSiblingIndex(cards.Count - 1);
        }
        int startIdx = 0;
        for (int i = 0; i < cards.Count; i++)
        {
            Card card = cards[i];
            if (card == hoveredCard) continue;
            card.transform.SetSiblingIndex(startIdx++);
        }
        
    }

    public void UnsetHoveredCard(Card card)
    {
        if (hoveredCard == card)
        {
            hoveredCard = null;
            UpdateCardPositions(500);
        }
    }

    void Draw()
    {
        Card newCard = drawPile.Draw();
        if (newCard != null) {
            cards.Add(newCard);
            newCard.hand = this;
            newCard.transform.SetParent(transform);
            newCard.transform.localScale = new Vector3(0.6f,0.6f,1);
            newCard.SetDesiredScale(Vector3.one, 1, null);
            HandSizeChanged();
        }
    }

}
