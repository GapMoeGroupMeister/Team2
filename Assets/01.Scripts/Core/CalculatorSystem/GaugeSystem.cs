using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodGauge : MonoBehaviour
{
    [SerializeField] Slider _foodBar;
    [SerializeField] Slider _scrapBar;
    private int _food;
    private int _scrap;
    private bool gaugeTest = false;
    private HowMuchDefeat _lose;
    private WarDayValue _dayChanges;

    private void Awake()
    {
        _scrapBar.value = 0;
        _foodBar.value = 0;
        _dayChanges = GetComponent<WarDayValue>();
        _lose = GetComponent<HowMuchDefeat>();
        _food = 0;
        _scrap = 0;
    }

    private void Update()
    {
        _foodBar.maxValue = 700 + (_lose.defeat + 1) * (_dayChanges.daycycle * 10);
        _scrapBar.maxValue = 700 + (_lose.defeat + 1) * (_dayChanges.daycycle * 10);
        _foodBar.value = _food;
        _scrapBar.value = _scrap;
        /*if (_foodBar.value >= _foodBar.maxValue && _scrapBar.value >= _scrapBar.maxValue)
        {
            gaugeTest = true;
        }*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Food"))
        {
            Destroy(collision.gameObject);
            _food += Random.Range(5, 16);
        }
        if (collision.gameObject.CompareTag("Scrap"))
        {
            Destroy(collision.gameObject);
            _scrap += Random.Range(5, 16);
        }
    }
}
