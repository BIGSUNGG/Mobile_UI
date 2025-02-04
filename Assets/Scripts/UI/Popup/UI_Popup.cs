using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using System;
using DG.Tweening;

public enum PopupAnimationType
{
    // ����Ʈ ���� (None)
    None,
    // Ȯ�� �˾� (Scale)
    ScaleUp,
    // ���̵� �̵� �˾� (Move)
    UpToDown,
    DownToUp,
    LeftToRight,
    RightToLeft,
}

public class UI_Popup : UI_Base
{
    [TabGroup("UI")]
    public CanvasGroup CanvasGroup;

    [SerializeField, TabGroup("Animation"), Tooltip("�˾��� ������ �� ����� �ִϸ��̼� ����")] 
    PopupAnimationType _openAnimation = PopupAnimationType.None;
    [SerializeField, TabGroup("Animation"), Tooltip("�˾��� ������ �� ����� �ִϸ��̼� ����")] 
    PopupAnimationType _closeAnimation = PopupAnimationType.None;

    [TabGroup("Animation"), Tooltip("�ִϸ��̼��� ������ Ʈ������"), ShowIf("@this._openAnimation != PopupAnimationType.None")]
    public RectTransform AnimatedRectTransform;

    public UnityEvent<UI_Popup> OnFinishOpenAnimationEvent { get; set; } = new UnityEvent<UI_Popup>();
    public UnityEvent<UI_Popup> OnFinishCloseAnimationEvent { get; set; } = new UnityEvent<UI_Popup>();

    public override void Awake()
    {
        base.Awake();

        if (CanvasGroup == null)
            CanvasGroup = GetComponent<CanvasGroup>();
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    public virtual void Open(bool immediately = false)
    {
        StartOpenAnimation();
    }

    public virtual void Close(bool immediately = false)
    {
        StartCloseAnimation();
    }

    #region Animation
    void StartOpenAnimation(bool immediately = false)
    {
        if(immediately || _openAnimation == PopupAnimationType.None)
        {
            OnFinishOpenAnimation();
        }
        else if(_openAnimation == PopupAnimationType.ScaleUp)
        {
            Vector3 originScale = AnimatedRectTransform.localScale;
            Vector3 targetScale = AnimatedRectTransform.localScale * 1.2f;

            Sequence sequence = DOTween.Sequence();
            sequence.Append(AnimatedRectTransform.DOScale(targetScale, 0.125f).SetEase(Ease.OutSine));
            sequence.Append(AnimatedRectTransform.DOScale(originScale, 0.125f).SetEase(Ease.OutSine));
            sequence.AppendCallback(OnFinishOpenAnimation);
        }
        else
        {
            throw new NotImplementedException();
        }
    }

    protected virtual void OnFinishOpenAnimation()
    {
        OnFinishOpenAnimationEvent.Invoke(this);
    }

    void StartCloseAnimation(bool immediately = false)
    {
        if (immediately || _closeAnimation == PopupAnimationType.None)
        {
            OnFinishCloseAnimation();
        }
        else
        {
            throw new NotImplementedException();
        }
    }

    protected virtual void OnFinishCloseAnimation()
    {
        OnFinishCloseAnimationEvent.Invoke(this);
    }

    #endregion
}
