using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoveCalcul : MonoBehaviour
{
    [SerializeField]Slider _loveBar;
    private bool _happyEnd = false;
    private bool _badEnding = false;
    [SerializeField] private float _value = 100;
    private bool _loveValue = false;


    private void Awake()
    {
        _loveBar.maxValue = 200;
        Reset();
    }

    private void Update()
    {
        _loveBar.value = _value;
        _badEnding = false;
        _happyEnd = false;
        if (_loveBar.value == 0)
        {
            _badEnding = true;
        }
        else if (_loveBar.value == 200)
        {
            _happyEnd = true;
        }
    }
    public void PlusLoveGauge()
    {
        _loveBar.value += Random.Range(5, 16);
    }

    public void MinusLoveGauge()
    {
        _loveBar.value -= Random.Range(5, 16);
    }

    public void RandomSystem()
    {
        if(Random.Range(1, 11) <= 5)
        {
            _value -= Random.Range(1, 6);
        }
        else
        {
            _value += Random.Range(1, 6);
        }
    }

    private void Reset()
    {
        if(_loveValue == false)
        {
            _loveBar.value = 100;
            _loveValue = true;
        }
        _loveBar.value = _value;
    }
}
