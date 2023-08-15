using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string spritePath;
    public int health;
    public Enemies.EnemyData enemyData;
    public Dictionary<Cards.EffectType, int> activeEffects = new Dictionary<Cards.EffectType, int>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (Cards.EffectType i in Enum.GetValues(typeof(Cards.EffectType)))
        {
            activeEffects.Add(i, 0);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetEnemyData(Enemies.EnemyData enemyData) {
        this.enemyData = enemyData;
        health = enemyData.health;
    }

    public void ApplyAcid(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (activeEffects[Cards.EffectType.Armor] > 0)
            {
                activeEffects[Cards.EffectType.Armor] = activeEffects[Cards.EffectType.Armor] - 1;
            } else {
                activeEffects[Cards.EffectType.Acid] = activeEffects[Cards.EffectType.Acid] + 1;
            }

        }
    }

    public void ApplyDamage(int amount) {
        int armor = activeEffects[Cards.EffectType.Armor];
        int damage = amount - armor;

        if (damage > 0) 
        {
            health -= damage;
        }
    }

    public void ApplyFire(int amount) {
        activeEffects[Cards.EffectType.Fire] = activeEffects[Cards.EffectType.Fire] + 1;
    }

    public void PlayCard(List<Cards.Effect> effects)
    {
        foreach (Cards.Effect effect in effects)
        {
            switch (effect.effectType) {
                case Cards.EffectType.Acid:
                    ApplyAcid(effect.value);
                    break;
                case Cards.EffectType.Damage:
                    ApplyDamage(effect.value);
                    break;
                case Cards.EffectType.Fire:
                    ApplyFire(effect.value);
                    break;
            }
        }
    }
}
