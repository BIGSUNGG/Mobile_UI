using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using System;
using DG.Tweening;
using Extensions;

public enum PopupAnimationType
{
    None,
    ScaleUpDown,
}

public class UI_Popup : UI_Behaviour
{
    [TabGroup("UI")]
    public CanvasGroup CanvasGroup;

    [SerializeField, TabGroup("Animation"), Tooltip("팝업이 열릴 때 실행될 애니메이션 종류")]
    UI_Animation _openAnimation;
    [SerializeField, TabGroup("Animation"), Tooltip("팝업이 닫힐 때 실행될 애니메이션 종류")]
    UI_Animation _closeAnimation;

    [TabGroup("Animation"), Tooltip("애니메이션을 적용할 UI 오브젝트"), ShowIf("@this._openAnimation != null || this._closeAnimation != null")]
    public UI_Behaviour AnimatedUI;

    public UnityEvent<UI_Popup> OnFinishOpenAnimationEvent { get; set; } = new UnityEvent<UI_Popup>();
    public UnityEvent<UI_Popup> OnFinishCloseAnimationEvent { get; set; } = new UnityEvent<UI_Popup>();

    public override void Awake()
    {
        base.Awake();

        if (CanvasGroup == null)
            CanvasGroup = GetComponent<CanvasGroup>();

        if(_openAnimation !=null)
        {
            _openAnimation.DetachReference();
            _openAnimation.OnFinishAnimationEvent.AddListener(OnFinishOpenAnimation);
        }

        if (_closeAnimation != null)
        {
            _closeAnimation.DetachReference();
            _closeAnimation.OnFinishAnimationEvent.AddListener(OnFinishCloseAnimation);
        }
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
        if(immediately || _openAnimation == null)
        {
            OnFinishOpenAnimation();
            return;
        }

        _openAnimation.StartAnimation(AnimatedUI);
    }

    void StartCloseAnimation(bool immediately = false)
    {
        if (immediately || _closeAnimation == null)
        {
            OnFinishCloseAnimation();
            return;
        }

        _closeAnimation.StartAnimation(AnimatedUI);
    }

    protected virtual void OnFinishOpenAnimation()
    {
        OnFinishOpenAnimationEvent.Invoke(this);
    }

    protected virtual void OnFinishCloseAnimation()
    {
        OnFinishCloseAnimationEvent.Invoke(this);
    }

    #endregion
}
