using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{

    public Characters.CharacterData characterData;
    public int health;
    public Slider healthBar;
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

    public void SetCharacterData(Characters.CharacterData characterData)
    {
        health = characterData.health;
        this.characterData = characterData;
    }

    public void UpdateHealth(int newValue)
    {
        health = newValue;
        healthBar.value = health;
        if (health <= 0) {
            Destroy(gameObject);
        }
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
            UpdateHealth(health - damage);
        }
    }

    public void ApplyFire(int amount) {
        activeEffects[Cards.EffectType.Fire] = activeEffects[Cards.EffectType.Fire] + 1;
    }


    public void PlayCard(Card card)
    {
        List<Cards.Effect> effects = card.cardData.effects;
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
