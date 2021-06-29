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

    List<CardBehavior> cardList = new List<CardBehavior>();

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

        cardList.Add(cardFarmer.GetComponent<CardBehavior>());
        cardList.Add(cardPriest.GetComponent<CardBehavior>());
    }

    [Command]
    public void CmdDealCards()
    {
        GameObject card = Instantiate(cardFarmer, playerSideObject.transform);
        NetworkServer.Spawn(card, connectionToClient);
        card = Instantiate(cardPriest, playerSideObject.transform);
        NetworkServer.Spawn(card, connectionToClient);
    }
}
