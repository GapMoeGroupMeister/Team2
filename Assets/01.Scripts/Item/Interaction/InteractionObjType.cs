using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractionObjType : MonoBehaviour
{

    protected abstract void Interaction();

    protected virtual void Search()
    {
        
    }
    



    protected virtual void PickedUp()
    {
        Destroy(gameObject);
    }
    
}
