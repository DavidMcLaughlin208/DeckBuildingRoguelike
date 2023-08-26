using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int slotPos;
    public Enemy enemy;
    public GameObject enemyPrefab;
    public MouseHandler mouseHandler;

     // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0, 100) > 50) {
            enemy = Instantiate(enemyPrefab, transform).GetComponent<Enemy>();
            enemy.SetEnemyData(Enemies.enemies["ectomorph"]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        // if (mouseHandler.heldCard != null && mouseHandler.heldCard.cardData.target == Cards.Target.Slot) {
        //     mouseHandler.lr.SetPosition(1, transform.position);
        // }
        //Output to console the GameObject's name and the following message
        Debug.Log("Cursor Entering " + name + " GameObject");
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {

    }

    public bool CheckRequirements(List<Cards.Requirements> reqs) {
        for (int i = 0; i < reqs.Count; i++) {
            Cards.Requirements req = reqs[i];
            if (req == Cards.Requirements.Filled) {
                return enemy != null;
            }
        }
        return true;
    }

    public void PlayCard(Card card)
    {
        if (enemy) {
            enemy.PlayCard(card.cardData.effects);
        }
    }
}
