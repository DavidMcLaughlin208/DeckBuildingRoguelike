using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CombatActionParams
{
    public Slot slot { get; set; }
    public Card card { get; set; }
}

public class CombatManager : MonoBehaviour
{
    public DrawPile drawPile;
    public DiscardPile discardPile;
    public Hand hand;
    public GameObject combatUi;
    public GameManager gm;
    public List<CombatActionParams> combatQueue = new List<CombatActionParams>();

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    void Start()
    {
        drawPile.SetCards(new List<Cards.CardData>(gm.deck.cards));
    }

    public void AppendToCombatQueue(Card card, Slot slot)
    {
        CombatActionParams combatActionParams = new();
        combatActionParams.slot = slot;
        combatActionParams.card = card;
        combatQueue.Add(combatActionParams);
    }

    // Update is called once per frame
    void Update()
    {
        if (combatQueue.Count > 0)
        {
            CombatActionParams currentAction = combatQueue[0]; 
            combatQueue.RemoveAt(0);
            if (currentAction.slot)
            {
                currentAction.slot.PlayCard(currentAction.card);
            } else {
                PlayCard(currentAction.card);
            }
        }
    }

    void Reset()
    {

    }

    public void PlayCard(Card card)
    {
        
    }
}
