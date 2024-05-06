using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodInteraction : InteractionObject
{
    [SerializeField] private int foodPrice = 0;

    private void Awake()
    {
        foodPrice = Random.Range(50, 70);
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
            priceUi.text = dollor + foodPrice.ToString();
        }
    }

    protected override void Interaction()
    {
        base.Interaction();

        if (makeInteraction == true)
        {
            PickedUp();
            foodMoney += foodPrice;
            interactionUi.text = "음식을 주웠다.";
        }
    }
}
