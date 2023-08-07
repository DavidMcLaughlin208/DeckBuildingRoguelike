using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public GameObject drawPilePrefab;
    public GameObject drawPile;
    public GameObject discardPilePrefab;
    public GameObject discardPile;
    public GameObject handPrefab;
    public GameObject hand;
    public GameObject combatUiPrefab;
    public GameObject combatUi;

    // Start is called before the first frame update
    void Start()
    {
        drawPile = Instantiate(drawPilePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        discardPile = Instantiate(discardPilePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        hand = Instantiate(handPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Debug.Log("Creating UI");
        combatUi = Instantiate(combatUiPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        Debug.Log(combatUi);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Reset()
    {

    }
}
