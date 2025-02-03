using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Unit : UI_Base, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerClickHandler
{    
    // ���콺�� UI ���� ���� �� ũ�⿡ ���� �ִϸ��̼��� ��������
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
