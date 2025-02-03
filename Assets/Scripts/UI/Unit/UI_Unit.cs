using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Unit : UI_Base, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerClickHandler
{    
    // 마우스가 UI 위에 있을 때 크기에 대한 애니메이션을 적용할지
    [SerializeField, TabGroup("Animation")] bool _isPointerSizeUp = false;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
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
