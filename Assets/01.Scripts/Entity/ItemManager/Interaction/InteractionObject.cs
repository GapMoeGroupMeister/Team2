using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InteractionObject : InteractionObjType
{
    [SerializeField] protected Text priceUi;
    [SerializeField] protected Text interactionUi;
    [SerializeField] protected Text messageUi;
    [SerializeField] protected string dollor = "$";


    [SerializeField] protected PlayerMovement playerObject;
    [SerializeField] protected GameObject scrap;
    [SerializeField] protected GameObject food;
    [SerializeField] protected int scrapMoney = 0;
    [SerializeField] protected int foodMoney = 0;
    [SerializeField] protected HowMuchDefeat defeatValue;
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
        }
    }
}
