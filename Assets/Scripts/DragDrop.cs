using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Mirror;

public class DragDrop : NetworkBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
	public Canvas canvas;
	public CanvasGroup cGroup;
	public RectTransform cardTransform;
	public PlayerBehavior player;

	private GameObject startingZone;
	private GameObject hoveringDropZone;
	private Vector2 startPosition;
	public Vector2 startingSize;
	private bool isOverDropZone;
	private Ray ray;
	private RaycastHit hit;

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (!hasAuthority) return;
		//transform.SetAsLastSibling();
		startingZone = transform.parent.gameObject;
		startPosition = transform.position;
		cGroup.alpha = .5f;
		cGroup.blocksRaycasts = false;
		startingSize = GetComponent<RectTransform>().transform.localScale;
		GetComponent<RectTransform>().transform.localScale *= 0.5f;
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (!hasAuthority) return;
		cardTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
		transform.SetParent(canvas.transform, true);
	}

	public void OnDrop(PointerEventData eventData)
	{
		if (!hasAuthority) return;
		Debug.Log("something has been dropped on " + gameObject.name);
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (!hasAuthority) return;
		cGroup.alpha = 1f;
		cGroup.blocksRaycasts = true;
		GetComponent<RectTransform>().transform.localScale = startingSize;
		NetworkIdentity networkIdentity = NetworkClient.connection.identity;
		player = networkIdentity.GetComponent<PlayerBehavior>();
		player.PlayCard(gameObject);
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
