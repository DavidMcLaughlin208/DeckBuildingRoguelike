using System;
using UnityEngine;
using System.Collections.Generic;
static class Cards
{

    public class CardData {
        public string Name { get; set; }
        public string Description { get; set; }

        public CardData(string Name, string Description) {
            this.Name = Name;
            this.Description = Description;
        }
    };

    public static Dictionary<string, Dictionary<string, CardData>> cards = new Dictionary<string, Dictionary<string, CardData>>() {
        {"Traveler", new Dictionary<string, CardData>() {
            {"shot", new CardData("Shot", "Shoots")},
        }},
    };
}