using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DieSceneManager : MonoBehaviour
{
    [SerializeField] Image _fadeImage;
    [SerializeField] private RectTransform _dieText;
    [SerializeField] private CanvasGroup _restartButton;
    
    private void Start()
    {
        Sequence sq = DOTween.Sequence();
        sq.Append(_fadeImage.DOFade(0, 0.5f))
            .Append(_dieText.DOAnchorPosY(124f, 0.5f).SetEase(Ease.InSine))
            .Append(_restartButton.DOFade(1f, 0.5f))
            .OnComplete(() => _fadeImage.gameObject.SetActive(false));
        
        sq.Play();
    }
    
    public void Restart()
    {
        SceneManager.LoadScene("StartScene");
    }
}
