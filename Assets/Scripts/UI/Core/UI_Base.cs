using UnityEngine.EventSystems;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

public class UI_Base : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerClickHandler
{
    // ���콺�� UI ���� ���� �� ũ�⿡ ���� �ִϸ��̼��� ��������
    [SerializeField, TabGroup("Animation")] bool _isPointerSizeUp = false;
    [HideInInspector] public RectTransform RectTransform { get; set; }

    public virtual void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
    }

    public virtual void Start()
    {
        
    }

    public virtual void Update()
    {
        
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        if (_isPointerSizeUp)
        {
            DOTween.Kill(RectTransform);
            RectTransform.DOScale(1.1f, .2f);
        }
    }
    public virtual void OnPointerExit(PointerEventData eventData)
    {
        if (_isPointerSizeUp)
        {
            DOTween.Kill(RectTransform);
            RectTransform.DOScale(1f, .2f);
        }
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {

    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {

    }
}
