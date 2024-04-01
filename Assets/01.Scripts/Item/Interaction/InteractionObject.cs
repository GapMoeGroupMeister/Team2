using UnityEngine;

public class InteractionObject : InteractionObjType
{

    private PlayerMovement Galahad;
    private PlayerMovement playerObject =null;
    public GameObject Scrap;

    

    private void Awake()
    {
        playerObject = FindObjectOfType<PlayerMovement>();

    }

    private void Update()
    {
        Search();
        Interaction();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enable = true;
        }
    }


    protected virtual void Search()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Collider2D coll = Physics2D.OverlapCircle(worldPoint, 0.5f);

            if (enable && coll != null)
            {
                makeSearch = true;
            }

            if (makeSearch == true)
            {
                Debug.Log(coll);
            }
        }
    }

    protected virtual void Interaction()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Collider2D coll = Physics2D.OverlapCircle(worldPoint, 0.5f);

            if (enable && coll != null)
            {
                makeInteraction = true;
            }

            if (makeInteraction == true)
            {
                Debug.Log("Interaction" + coll);
            }
        }
    }


    protected override void PickedUp()
    {
        base.PickedUp();
    }
}
