using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies
{

    public class EnemyData {
        public string name;
        public string spritePath;
        public int health;
    }


    public static Dictionary<string, EnemyData> enemies = new Dictionary<string, EnemyData>() {
        {"ectomorph", new EnemyData() { name="Ectomorph", spritePath="", health=10 } },
    };
}
