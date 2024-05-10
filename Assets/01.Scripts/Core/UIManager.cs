using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private Transform _hpIconContent;
    [SerializeField] private Sprite _healthyHpIcon;
    [SerializeField] private Sprite _destroyedHpIcon;
    
    [SerializeField] private Image[] hpIcons;
    [SerializeField] private Image weaponIcon;
    [SerializeField] private Image _coolTimePercentFill;
    private void Awake()
    {
        hpIcons = _hpIconContent.GetComponentsInChildren<Image>();
    }

    public void SetHpIcon(int hpValue, int maxHpValue)
    {
        if (hpValue == 0) return;
        for (int i = 0; i < hpValue-1; ++i)
        {
            hpIcons[i].sprite = _healthyHpIcon;
        }
        for (int i = hpValue-1; i < maxHpValue; ++i)
        {
            hpIcons[i].sprite = _destroyedHpIcon;
        }
    }

    public void SetCurrentWeapon(Sprite sprite)=>weaponIcon.sprite = sprite;

    public void SetCoolTimeImage(float percentValue) => _coolTimePercentFill.fillAmount = percentValue;
}
