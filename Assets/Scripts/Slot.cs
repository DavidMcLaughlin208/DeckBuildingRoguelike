using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public int slotPos;
    public Enemy enemy;
    public GameObject enemyPrefab;
     // Start is called before the first frame update
    void Start()
    {
        if (Random.Range(0, 100) > 50) {
            enemy = Instantiate(enemyPrefab, transform).GetComponent<Enemy>();
            enemy.transform.localScale = new Vector3(-1, 1, 1);
            enemy.transform.localScale = new Vector3(1,1,1);
            enemy.SetEnemyData(Enemies.enemies["ectomorph"]);
        }
    }

    // Update is called once per frame
    void Update()
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
