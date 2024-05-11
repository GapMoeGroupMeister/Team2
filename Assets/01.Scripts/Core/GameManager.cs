using Cinemachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager>
{
    [field:SerializeField] public PlayerController PlayerController { get; set; }
    [field:SerializeField] public InputManager InputManager { get; private set; }
    [field:SerializeField] public CinemachineVirtualCamera VirtualCamera { get; set; }
    [SerializeField] private CanvasGroup _settingPanel;

    public void SettingOn()
    {
        _settingPanel.gameObject.SetActive(true);
        _settingPanel.DOFade(1f, 0.5f);
    }
    
    public void SettingOff()
    {
        _settingPanel.DOFade(0f, 0.5f).OnComplete(() => _settingPanel.gameObject.SetActive(false));
    }
}
