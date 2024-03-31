using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : InteractionObjType
{

    private PlayerMovement Galahad;
    private GameObject playerObject;

    private void Awake()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");

    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
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
                    Search();
                }
                
            }
            
        }
    }

    protected override void Interaction()
    {

    }

    protected override void Search()
    {
        
    }
}
