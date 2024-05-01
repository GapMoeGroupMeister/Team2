using System.Collections;
using UnityEngine;

public class InteractionObject : InteractionObjType
{

    private PlayerMovement Galahad;
    private PlayerMovement playerObject = null;
    [SerializeField] private GameObject Scrap;
    private HowMuchDefeat defeatValue;

    protected float lootingTime = 2f;
    protected bool isLooting = false;

    private IEnumerator LootingCoroutine()
    {
        isLooting = true;
        yield return new WaitForSeconds(lootingTime);
        isLooting = false;
    }

    private void StartLooting()
    {
        if (!isLooting)
        {
            StartCoroutine(LootingCoroutine());
        }
    }

    public void CancelLooting()
    {
        if (isLooting)
        {
            StopCoroutine(LootingCoroutine());
            isLooting = false;
        }
    }

    private void Awake()
    {
        playerObject = FindObjectOfType<PlayerMovement>();
        defeatValue = GetComponent<HowMuchDefeat>();

        if (defeatValue.defeat >= 4)
        {
            lootingTime = 2f - (defeatValue.defeat * 0.1f);
        }
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
                StartLooting();
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
