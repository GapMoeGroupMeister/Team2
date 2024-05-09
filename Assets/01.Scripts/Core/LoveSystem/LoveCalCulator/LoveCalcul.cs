using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoveCalcul : MonoBehaviour
{
    [SerializeField]Slider _loveBar;
    [SerializeField] public float _value = 100f;
    private bool _loveValue = false;
    private HowMuchDefeat defVal;

    private void Awake()
    {
        PlayDataManager.Instance.playData = PlayDataManager.Instance.LoadPlayData();
        defVal = GetComponent<HowMuchDefeat>();
        _loveBar.maxValue = 220;
    }

    private void Update()
    {
        //PlayDataManager.Instance.playData._loveValue = _value;
        _loveBar.value = _value;
        PlayDataManager.Instance.playData._loveValue = _value;
        PlayDataManager.Instance.SavePlayData();
    }
    /*public void PlusLoveGauge()
    {
        _value += Random.Range(5, 16);
        if(defVal.defeat >= 3)
        {
            _value += Random.Range(5, 16) / (defVal.defeat * 1.2f);
            PlayDataManager.Instance.playData._loveValue += _value;
            PlayDataManager.Instance.SavePlayData();
        }
    }

    public void MinusLoveGauge()
    {
        _value -= Random.Range(5, 16);
        PlayDataManager.Instance.playData._loveValue += _value;
        PlayDataManager.Instance.SavePlayData();
    }*/

    public void RandomSystem()
    {
        if(Random.Range(1, 11) <= 5)
        {
            _value -= Random.Range(1, 6);
            PlayDataManager.Instance.SavePlayData();
        }
        else
        {
            if (defVal.defeat < 2)
            {
                _value += Random.Range(1, 6);
            }
            else if (defVal.defeat >= 3)
            {
                _value += Random.Range(5, 16) / (defVal.defeat * 1.1f);
            }
            PlayDataManager.Instance.SavePlayData();
        }
    }

    private void Reset()
    {
        if(_loveValue == false)
        {
            PlayDataManager.Instance.playData._loveValue = 100;
            _loveValue = true;
        }
    }
}
