using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BodyInteraction : InteractionObject
{
    private int inItem = 0;

    private void Awake()
    {
        inItem = Random.Range(1, 10);
    }

    protected override void Search()
    {
        base.Search();

        if (makeSearch == true)
        {
            messageUi.text = "½ÃÃ¼´Ù.";
        }
    }

    protected override void Interaction()
    {
        base.Interaction();

        if (makeInteraction == true)
        {
            gameObject.SetActive(false);

            if (inItem > 5)
            {
                Instantiate(scrap);
                scrap.transform.position = transform.position;
            }
            else
            {
                Instantiate(food);
                food.transform.position = transform.position;
            }
        }
    }
}
