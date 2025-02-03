using UnityEngine.EventSystems;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

public class UI_Base : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerClickHandler
{
    // 마우스가 UI 위에 있을 때 크기에 대한 애니메이션을 적용할지
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
