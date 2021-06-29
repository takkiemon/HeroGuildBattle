using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropSlotBehavior : MonoBehaviour, IDropHandler
{
    GameObject tempGameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("something has been dropped on DA DROPSLOT");
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.gameObject.GetComponent<CardBehavior>() != null)
            {
                tempGameObject = eventData.pointerDrag.gameObject.GetComponent<CardBehavior>().gameObject;
                tempGameObject.transform.SetParent(gameObject.transform, false);
                return;
            }
        }
    }
}
