using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractionObjType : MonoBehaviour
{

    protected bool picked = false;
    protected abstract void Interaction();

    protected virtual void PickedUp()
    {
        Destroy(gameObject);
    }
    
}
