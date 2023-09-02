using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class MouseHandler : MonoBehaviour
{

    public GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    public Card heldCard = null;
    public Hand hand;
    public bool hasControl = true;
    public LineRenderer lr;
    public CombatManager combatManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (heldCard != null) {
        //     lr.SetPosition(0, Input.mousePosition);
        // }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Set up the new Pointer Event
            m_PointerEventData = new PointerEventData(m_EventSystem);
            //Set the Pointer Event Position to that of the mouse position
            m_PointerEventData.position = Input.mousePosition;

            //Create a list of Raycast Results
            List<RaycastResult> results = new List<RaycastResult>();

            //Raycast using the Graphics Raycaster and mouse click position
            m_Raycaster.Raycast(m_PointerEventData, results);

            //For every result returned, output the name of the GameObject on the Canvas hit by the Ray
            foreach (RaycastResult result in results)
            {
                Debug.Log("Hit " + result.gameObject.name);
                Card card = result.gameObject.GetComponent<Card>();
                if (card != null && card != heldCard) {
                    DropCard();
                    card.grabbed = true;
                    heldCard = card;
                    return;
                }
                Cards.Target target;
                bool isTarget = Enum.TryParse(result.gameObject.tag, out target);
                if (hasControl && isTarget && heldCard && heldCard.cardData.target == target) {
                    Slot slot = result.gameObject.GetComponent<Slot>();
                    if (slot) {
                        bool meetsReqs = slot.CheckRequirements(heldCard.cardData.requirements);
                        if (meetsReqs) {
                            combatManager.AppendToCombatQueue(heldCard, slot);
                            hand.Discard(heldCard);
                            heldCard = null;
                            return;
                        }
                    }
                    if (target == Cards.Target.General)
                    {
                        //bool meetsReqs = combatManager.CheckRequirements(heldCard.cardData.requirements);
                        combatManager.AppendToCombatQueue(heldCard, null);
                        hand.Discard(heldCard);
                        heldCard = null;
                        return;
                    }
                }


                
            }
            DropCard();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            if (heldCard) {
                DropCard();
            }
        }
    }
    void DropCard() {
        if (heldCard) {
            heldCard.posSpeed = 2000;
            heldCard.grabbed = false;
            heldCard = null;
        }
    }
}
