using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private Transform _hpIconContent;
    [SerializeField] private Sprite _healthyHpIcon;
    [SerializeField] private Sprite _destroyedHpIcon;
    
    [SerializeField] private Image[] hpIcons;
    
    private void Awake()
    {
        hpIcons = _hpIconContent.GetComponentsInChildren<Image>();
    }

    public void SetHpIcon(int hpValue, int maxHpValue)
    {
        Debug.Log(hpValue);
        for (int i = 0; i < hpValue-1; ++i)
        {
            hpIcons[i].sprite = _healthyHpIcon;
        }
        for (int i = hpValue-1; i < maxHpValue; ++i)
        {
            hpIcons[i].sprite = _destroyedHpIcon;
        }
        
    }
}
