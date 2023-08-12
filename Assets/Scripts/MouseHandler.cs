using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class MouseHandler : MonoBehaviour
{

    public GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;
    Card heldCard = null;
    public Hand hand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
                bool isGeneralPlay = result.gameObject.tag == "GeneralPlay";
                if (heldCard && isGeneralPlay) {
                    hand.Discard(heldCard);
                    heldCard = null;
                    return;
                }

                DropCard();
            }
        }
    }
    void DropCard() {
        if (heldCard) {
            heldCard.grabbed = false;
            heldCard = null;
        }
    }
}
