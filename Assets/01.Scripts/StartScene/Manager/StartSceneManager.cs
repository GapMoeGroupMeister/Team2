using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button _startButton; 
    [SerializeField] private Button _settingButton; 
    [SerializeField] private Button _exitButton;
    [SerializeField] private Button _settingCloseButton;
    
    [Header("Panels")]
    [SerializeField] private CanvasGroup _settingPanel;
    [SerializeField] private Image _blackImage;
    
    private void Start()
    {
        _blackImage.DOFade(0, 1).OnComplete(() => _blackImage.gameObject.SetActive(false));
        _startButton.onClick.AddListener(StartGame);
        _settingButton.onClick.AddListener(Setting);
        _exitButton.onClick.AddListener(Exit);
        _settingCloseButton.onClick.AddListener(CloseSetting);
    }

    private void CloseSetting()
    {
        _settingPanel.DOFade(0, 0.5f).OnComplete(() => _settingPanel.gameObject.SetActive(false));
    }

    private void Exit()
    {
        Application.Quit();
    }

    private void Setting()
    {
        _settingPanel.gameObject.SetActive(true);
        _settingPanel.DOFade(1, 0.5f);
    }

    private void StartGame()
    {
        _blackImage.gameObject.SetActive(true);
        _blackImage.DOFade(1, 1).OnComplete(() => SceneManager.LoadScene("MergeScene"));
    }
}
