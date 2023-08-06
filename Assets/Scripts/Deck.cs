using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    
    public List<Card> cards;
    // Start is called before the first frame update
    void Start()
    {
        cards = new List<Card>
        {
            // Default starter deck
            gameObject.AddComponent<Shot>(),
            gameObject.AddComponent<Shot>(),
            gameObject.AddComponent<LayTrap>(),
            gameObject.AddComponent<PiercingShot>(),
            gameObject.AddComponent<Grenade>(),
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
