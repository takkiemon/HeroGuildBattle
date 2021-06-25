using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
	public Canvas canvas;
	public CanvasGroup cGroup;
	public RectTransform cardTransform;

	private GameObject startingZone;
	private GameObject hoveringDropZone;
	private Vector2 startPosition;
	private bool isOverDropZone;

	public void OnBeginDrag(PointerEventData eventData)
	{
		//transform.SetAsLastSibling();
		startingZone = transform.parent.gameObject;
		startPosition = transform.position;
		cGroup.alpha = .5f;
		cGroup.blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		cardTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
		transform.SetParent(canvas.transform, true);
	}

	public void OnDrop(PointerEventData eventData)
	{
		Debug.Log("something has been dropped on " + gameObject.name);
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		cGroup.alpha = 1f;
		cGroup.blocksRaycasts = true;
		if (isOverDropZone)
		{
			transform.SetParent(hoveringDropZone.transform, false);
		}
		else
		{
			transform.position = startPosition;
			transform.SetParent(startingZone.transform);
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		isOverDropZone = true;
		hoveringDropZone = collision.gameObject;
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		isOverDropZone = false;
		hoveringDropZone = null;
	}

	// Start is called before the first frame update
	void Start()
    {
		canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
