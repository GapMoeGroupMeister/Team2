using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoveCalcul : MonoBehaviour
{
    [SerializeField]Slider _loveBar;
    private bool _happyEnd = false;
    private bool _badEnding = false;
    [SerializeField] private float _value = 100f;
    private bool _loveValue = false;
    private HowMuchDefeat defVal;

    private void Awake()
    {
        PlayerPrefs.SetFloat("LoveValue", _value);
        defVal = GetComponent<HowMuchDefeat>();
        _loveBar.maxValue = 220;
    }

    private void Update()
    {
        _loveBar.value = PlayerPrefs.GetFloat("LoveValue", 100);
        PlayerPrefs.Save();
        _badEnding = false;
        _happyEnd = false;
        if (_loveBar.value == 0)
        {
            _badEnding = true;
        }
        else if (_loveBar.value >= 200)
        {
            _happyEnd = true;
        }
    }
    public void PlusLoveGauge()
    {
        _value += Random.Range(5, 16);
        if(defVal.defeat >= 3)
        {
            _value += Random.Range(5, 16) / (defVal.defeat * 1.1f);
        }
    }

    public void MinusLoveGauge()
    {
        _value -= Random.Range(5, 16);
        if (defVal.defeat >= 3)
        {
            _value -= Random.Range(5, 16) / (defVal.defeat * 1.1f);
        }
    }

    public void RandomSystem()
    {
        if(Random.Range(1, 11) <= 5)
        {
            _value -= Random.Range(1, 6);
            if (defVal.defeat >= 3)
            {
                _value -= Random.Range(5, 16) / (defVal.defeat * 1.1f);
            }
        }
        else
        {
            _value += Random.Range(1, 6);
            if (defVal.defeat >= 3)
            {
                _value += Random.Range(5, 16) / (defVal.defeat * 1.1f);
            }
        }
    }

    /*private void Reset()
    {
        if(_loveValue == false)
        {
            _loveBar.value = 100;
            _loveValue = true;
        }
        _loveBar.value = _value;
    }*/
}
