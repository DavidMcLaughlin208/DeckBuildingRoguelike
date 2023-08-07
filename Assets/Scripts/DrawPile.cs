using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPile : MonoBehaviour
{
    public TextMesh drawText; 
    // Start is called before the first frame update
    void Start()
    {
        drawText = GameObject.Find("CombatManager").transform.Find("CombatUI/DrawPileUI/CountBackground/DrawPileTextCount").GetComponent<TextMesh>();
        drawText.text = "1";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
