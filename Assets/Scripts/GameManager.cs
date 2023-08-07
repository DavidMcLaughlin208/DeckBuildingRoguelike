using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Deck deck;
    public GameObject combatManager;
    public CombatManager combatManagerComp;

    void Awake()
    {
        deck = gameObject.AddComponent<Deck>();
        combatManagerComp = Instantiate(combatManager, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<CombatManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
