using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{

    [SerializeField] private Camera mainCamera;
    protected Vector2 leftLimit;
    protected Vector2 rightLimit;
    [SerializeField] protected GameObject archerPrefab;
    [SerializeField] protected GameObject cavarlyPrefab;
    protected int enemyCount;
    protected int enemyType;
    protected int enemyTypeCount;

    void Start()
    {
        mainCamera = Camera.main;
        leftLimit = mainCamera.ViewportToWorldPoint(new Vector3(0, 0));
        rightLimit = mainCamera.ViewportToWorldPoint(new Vector3(1, 1));
    }

    void Update()
    {
        enemyCount = Random.Range(7, 12);

        //if ()
        //{
            for (int i = 0; i <= enemyCount; i++)
            {
                enemyType = Random.Range(1, enemyTypeCount);

                switch (enemyType)
                {
                    case 1:
                    GameObject enemy = Instantiate(cavarlyPrefab);
                    enemy.transform.position = new Vector2 (Random.Range(leftLimit.x, rightLimit.x), Random.Range(leftLimit.y, rightLimit.y));
                    break;

                    case 2 :
                    enemy = Instantiate(archerPrefab);
                    enemy.transform.position = new Vector2(Random.Range(leftLimit.x, rightLimit.x), Random.Range(leftLimit.y, rightLimit.y));
                    break;
            }
            }
        //}
    }
}
