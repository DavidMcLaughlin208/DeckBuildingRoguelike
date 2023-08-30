using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public DrawPile drawPile;
    public DiscardPile discardPile;
    public Hand hand;
    public GameObject combatUi;
    public GameManager gm;
    public List<Action<Cards.CardData, Slot>> combatQueue = new List<Action<Cards.CardData, Slot>>();

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    void Start()
    {
        drawPile.SetCards(new List<Cards.CardData>(gm.deck.cards));
    }

    public void AppendToCombatQueue(Action<Cards.CardData, Slot> action)
    {
        combatQueue.Add(action);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Reset()
    {

    }
}
