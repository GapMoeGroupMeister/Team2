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
    private int _dayChanges;
    public int _levelUp;
    public bool gaugeTest = false;


    private void Awake()
    {
        _scrapBar.value = 0;
        _foodBar.value = 0;
        _levelUp = 0;
        _dayChanges = 0;
        _food = 0;
        _scrap = 0;
        _foodBar.maxValue = 100  + _dayChanges * _levelUp / 10;
        _scrapBar.maxValue = _foodBar.maxValue;
    }

    private void Update()
    {
        _foodBar.value = _food;
        _scrapBar.value = _scrap;
        if (_foodBar.value >= _foodBar.maxValue && _scrapBar.value >= _scrapBar.maxValue)
        {
            gaugeTest = true;
        }
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
