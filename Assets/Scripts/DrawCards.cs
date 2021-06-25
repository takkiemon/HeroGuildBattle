using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameObject canvasObject;
    public GameObject cardFarmer;
    public GameObject cardPriest;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
	{
        for (int i = 0; i < 3; i++)
		{
            GameObject card = Instantiate(cardFarmer, canvasObject.transform);
		}
	}
}
