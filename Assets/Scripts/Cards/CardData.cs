using System;
using UnityEngine;
using System.Collections.Generic;
public static class Cards
{

    public enum Target {
        Slot,
        General,
        AllSlots
    };

    public enum Requirements {
        Filled,
        Empty,
    };

    public enum EffectType {
        Acid,
        Damage,
        Fire,
        Piercing,
        Armor,
    };

    public class Effect {
        public EffectType effectType;
        public int value;

        public Effect(EffectType effectType, int value) {
            this.effectType = effectType;
            this.value = value;
        }
    };

    public class CardData {
        public string Name { get; set; }
        public string Description { get; set; }
        public Target target { get; set; }
        public List<Effect> effects { get; set; }
        public List<Requirements> requirements { get; set; }

        public CardData(string Name, string Description, Target target, List<Effect> effects, List<Requirements> requirements = null) {
            this.Name = Name;
            this.Description = Description;
            this.target = target;
            this.effects = effects;
            this.requirements = requirements;
        }
    };

    public static Dictionary<string, Dictionary<string, CardData>> cards = new Dictionary<string, Dictionary<string, CardData>>() {
        {"Traveler", new Dictionary<string, CardData>() {
            {"shot", new CardData("Shot", "Deal 1 Ballistic Damage", Target.Slot, new List<Effect>{ new Effect(EffectType.Damage, 4) }, new List<Requirements>{ Requirements.Filled} ) },
            {"incendiary-shot", new CardData("Incendiary Shot", "Deal 1 Ballistic Damage. Apply 1 Fire.", Target.Slot, new List<Effect>{ new Effect(EffectType.Damage, 1), new Effect(EffectType.Fire, 1) }, new List<Requirements>{ Requirements.Filled} ) },
            {"armor-up", new CardData("Armor Up", "Gain 1 Armor", Target.General, new List<Effect>{ new Effect(EffectType.Armor, 1) } ) },
        }},
    };
}