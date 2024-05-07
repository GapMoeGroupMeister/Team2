using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrapInteraction : InteractionObject
{
    [SerializeField] private int scrapPrice = 0;

    

    private void Awake()
    {
        scrapPrice = Random.Range(20, 100);
    }

    private void Update()
    {
        Search();
        Interaction();
    }

    protected override void Search()
    {
        base.Search();

        if (makeSearch == true)
        {
            priceUi.text = dollor + scrapPrice.ToString();
        }
    }

    protected override void Interaction()
    {
        base.Interaction();

        if (makeInteraction == true)
        {
            PickedUp();
            scrapMoney += foodMoney;
            interactionUi.text = "ÆóÇ°À» ÁÖ¿ü´Ù.";
        }
    }
}

