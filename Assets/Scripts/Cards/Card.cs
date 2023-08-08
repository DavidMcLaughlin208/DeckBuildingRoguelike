using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerClickHandler
{
    public Vector2 desiredPos;
    public float speed = 10f;
    public DiscardPile discardPile;
    public Hand hand; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, desiredPos, step);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        hand.Discard(this);
    }
}
