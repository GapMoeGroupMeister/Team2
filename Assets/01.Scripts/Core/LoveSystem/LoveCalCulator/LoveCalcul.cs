using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoveCalcul : MonoBehaviour
{
    [SerializeField]Slider _loveBar;
    public bool _happyEnd = false;
    public bool _badEnding = false;
    public static LoveCalcul _love;


    private void Awake()
    {
        //awake덕에 씬 전환시 값이 100으로 고정 후 시작
        //수정해야됨
        _loveBar.value = 100;
        _loveBar.maxValue = 200;
    }

    private void Update()
    {
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
            _loveBar.value -= Random.Range(1, 6);
        }
        else
        {
            _loveBar.value += Random.Range(1, 6);
        }
    }
}
