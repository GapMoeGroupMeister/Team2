using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractionObjType : MonoBehaviour
{

    private GameObject playerObject;

    protected bool picked = false;
    protected abstract void Interaction();

    protected virtual void Search()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log ("Search");
            }
        }
    }
    

    protected virtual void PickedUp()
    {
        Destroy(gameObject);
    }
    
}
