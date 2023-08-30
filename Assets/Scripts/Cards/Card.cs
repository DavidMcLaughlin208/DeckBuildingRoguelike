using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Card : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 desiredPos;
    public Vector3 desiredScale;
    public float posSpeed = 250f;
    public float scaleSpeed = 10f;
    public DiscardPile discardPile;
    public Hand hand; 
    public GameObject myGameObject;
    private bool reachedDesiredPos;
    private bool reachedDesiredScale;
    private Action moveCallback;
    private Action scaleCallback;
    public Cards.CardData cardData;
    public TextMeshProUGUI cardTitle;
    public TextMeshProUGUI cardDescription;

    public bool grabbed = false;
    // Start is called before the first frame update
    void Awake()
    {
        desiredScale = Vector3.one;
    }
    void Start()
    {
        myGameObject = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (grabbed) {
            Vector3 mousePos = Input.mousePosition;
            transform.position = mousePos;
            transform.localScale = Vector3.one;
        } else {
            float posStep =  posSpeed * Time.deltaTime; // calculate distance to move
            if (transform.position != desiredPos) {
                transform.position = Vector3.MoveTowards(transform.position, desiredPos, posStep);
            } else if (!reachedDesiredPos) {
                reachedDesiredPos = true;
                moveCallback?.Invoke();
            }
            if (transform.localScale != desiredScale) 
            {
                float scaleStep = scaleSpeed * Time.deltaTime; // calculate distance to move
                transform.localScale = Vector3.MoveTowards(transform.localScale, desiredScale, scaleStep);
            } else if (!reachedDesiredScale) {
                reachedDesiredScale = true;
                scaleCallback?.Invoke();
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
        transform.localScale = new Vector3(1.5f, 1.5f, 1);
        SetDesiredScale(new Vector3(1.5f, 1.5f, 1), 1, null);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        hand.UnsetHoveredCard(this);
        SetDesiredScale(Vector3.one, 20f, null);
    }
    public void SetDesiredPos(Vector3 desiredPos, float speed, Action callback) 
    {
        this.posSpeed = speed;
        this.desiredPos = desiredPos;
        reachedDesiredPos = false;
        moveCallback = callback;
    }
    public void SetDesiredScale(Vector3 desiredScale, float speed, Action callback)
    {
        this.desiredScale = desiredScale;
        scaleSpeed = speed;
        scaleCallback = callback;
        reachedDesiredScale = false;
    }
    public void SetData(Cards.CardData cardData)
    {
        this.cardData = cardData;
        cardTitle.text = cardData.Name;
        cardDescription.text = cardData.Description;
    }
}
