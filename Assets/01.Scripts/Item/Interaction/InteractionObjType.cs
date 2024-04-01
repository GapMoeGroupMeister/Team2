using UnityEngine;

public abstract class InteractionObjType : MonoBehaviour
{
    protected bool enable = false;
    protected bool makeInteraction = false;
    protected bool makeSearch = false;
    protected bool searchScrap = false;


    protected virtual void PickedUp()
    {
        Destroy(gameObject);
    }
    
}
