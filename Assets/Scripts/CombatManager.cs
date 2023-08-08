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

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    void Start()
    {
        drawPile.SetCards(new List<Card>(gm.deck.cards));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Reset()
    {

    }
}
