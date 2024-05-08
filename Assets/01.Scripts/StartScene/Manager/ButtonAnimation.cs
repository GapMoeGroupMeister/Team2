using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float _scale = 1.1f;
    [SerializeField] private float _duration = 0.3f;
    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(_scale, _duration);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(1f, _duration);
    }
}