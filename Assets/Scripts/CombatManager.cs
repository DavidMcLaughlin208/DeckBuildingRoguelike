using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public GameObject drawPile;
    public DrawPile drawPileComp;
    public GameObject discardPile;
    public DiscardPile discardPileComp;
    public GameObject hand;
    public Hand handComp;

    // Start is called before the first frame update
    void Start()
    {
        drawPileComp = drawPile.GetComponent<DrawPile>();
        discardPileComp = discardPile.GetComponent<DiscardPile>();
        handComp = hand.GetComponent<Hand>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Reset()
    {

    }
}
