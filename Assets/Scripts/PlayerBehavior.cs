using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerBehavior : NetworkBehaviour
{
    public GameObject cardFarmer;
    public GameObject cardPriest;

    public GameObject playerSideObject;
    public GameObject questSlotObject;
    public GameObject enemyLeftObject;
    public GameObject enemyRightObject;

    List<GameObject> cardList = new List<GameObject>();

    public enum CardState
	{
        Dealt,
        Played
	}

	public override void OnStartClient()
	{
		base.OnStartClient();

        playerSideObject = GameObject.Find("PlayerSide");
        questSlotObject = GameObject.Find("BackgroundPanel");
        enemyLeftObject = GameObject.Find("LeftOppSide");
        enemyRightObject = GameObject.Find("RightOppSide");
    }

    [Server]
	public override void OnStartServer()
	{
		base.OnStartServer();

        cardList.Add(cardFarmer);
        cardList.Add(cardPriest);
    }

    [Command]
    public void CmdDealCards()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject card = Instantiate(cardList[Random.Range(0, cardList.Count)], playerSideObject.transform);
            NetworkServer.Spawn(card, connectionToClient);
            RpcShowCard(card, CardState.Dealt);
        }
    }

    [ClientRpc]
    void RpcShowCard(GameObject card, CardState type)
	{
        if (type == CardState.Dealt)
		{
            if (hasAuthority)
			{
                card.transform.SetParent(playerSideObject.transform, false);
			}
            else
			{
                card.transform.SetParent(enemyLeftObject.transform, false);
			}
		}
        else if (type == CardState.Played)
		{

		}
	}
}
