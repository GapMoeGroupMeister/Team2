using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Ease _ease;
    [SerializeField] private float _scale = 1.1f;
    [SerializeField] private float _duration = 0.3f;
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(_scale, _duration).SetEase(_ease);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1f, _duration).SetEase(_ease);
    }
}