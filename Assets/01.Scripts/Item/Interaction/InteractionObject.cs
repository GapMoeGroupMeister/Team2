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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            string tagValue = gameObject.tag;
            Debug.Log(tagValue);

            if (playerObject != null)
            {
                PlayerMovement playerMovement = playerObject.GetComponent<PlayerMovement>();
                if (playerMovement != null)
                {
                    playerMovement.SetTagValue(tagValue);
                    
                }
                
            }
            
        }
    }

    protected override void Interaction()
    {

    }
}
