using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Card : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 desiredPos;
    public float speed = 250f;
    public DiscardPile discardPile;
    public Hand hand; 
    public GameObject myGameObject;
    private bool reachedDesiredPos;
    private Action moveCallback;
    public Cards.CardData cardData;
    public TextMeshProUGUI cardTitle;
    public TextMeshProUGUI cardDescription;

    public bool grabbed = false;
    // Start is called before the first frame update
    void Start()
    {
        myGameObject = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        float step =  speed * Time.deltaTime; // calculate distance to move
        if (grabbed) {
            Vector3 mousePos = Input.mousePosition;
            transform.position = mousePos;
        } else {
            if (transform.position != desiredPos) {
                transform.position = Vector3.MoveTowards(transform.position, desiredPos, step);
            } else if (!reachedDesiredPos) {
                reachedDesiredPos = true;
                moveCallback?.Invoke();
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //grabbed = !grabbed;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hand.SetHoveredCard(this);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        hand.UnsetHoveredCard(this);
    }
    public void SetDesiredPos(Vector3 desiredPos, float speed, Action callback) 
    {
        this.speed = speed;
        this.desiredPos = desiredPos;
        reachedDesiredPos = false;
        moveCallback = callback;
    }
    public void SetData(Cards.CardData cardData)
    {
        this.cardData = cardData;
        cardTitle.text = cardData.Name;
        cardDescription.text = cardData.Description;
    }
}
