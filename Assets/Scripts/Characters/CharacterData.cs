using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characters
{

    public class CharacterData {
        public string name;
        public string spritePath;
        public int health;
    }


    public static Dictionary<string, CharacterData> characters = new Dictionary<string, CharacterData>() {
        {"time-traveler", new CharacterData() { name="Time Traveler", spritePath="", health=10 } },
    };
}
