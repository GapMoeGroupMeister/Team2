using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionObject : InteractionObjType
{

    private PlayerMovement Galahad;
    public GameObject playerObject;
    public GameObject Scrap;

    private void Awake()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            string tagValue = gameObject.tag;


            if (playerObject != null)
            {
                PlayerMovement playerMovement = playerObject.GetComponent<PlayerMovement>();
                if (playerMovement != null)
                {
                    playerMovement.SetTagValue(tagValue);
                    Debug.Log(tagValue);

                }

            }

        }
    }


    protected void Search()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Collider2D coll = Physics2D.OverlapCircle(worldPoint, 0.5f);

            if (coll == Scrap)
            {
                PickedUp();
            }
        }
    }

    
    protected override void Interaction()
    {

    }

    
}
