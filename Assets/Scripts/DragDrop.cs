using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
	public Canvas canvas;
	public CanvasGroup cGroup;
	public RectTransform cardTransform;

	public void OnBeginDrag(PointerEventData eventData)
	{
		transform.SetAsLastSibling();
		cGroup.alpha = .5f;
		cGroup.blocksRaycasts = false;
	}

	public void OnDrag(PointerEventData eventData)
	{
		cardTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
	}

	public void OnDrop(PointerEventData eventData)
	{
		throw new System.NotImplementedException();
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		cGroup.alpha = 1f;
		cGroup.blocksRaycasts = true;
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
