using UnityEngine.Events;
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using System;
using DG.Tweening.Core;

public enum UI_AnimtaionType
{ 
    None,
    ScaleToTarget,
    ScaleRatio,
    MoveToTarget,
    RotateToTarget,
}

[Serializable]
public struct UI_AnimationInfo
{
    public UI_AnimtaionType AnimationType;
    public SequenceType SequenceType;

    [ShowIf("@this.SequenceType", SequenceType.Insert)]
    public float InsertTime;
    public float Delay;
    public float Duration;
    public Ease Ease;

    [ShowIf("@this.AnimationType == UI_AnimtaionType.ScaleRatio || this.AnimationType == UI_AnimtaionType.RotateToTarget")]
    public float Value;

    [ShowIf("@this.AnimationType == UI_AnimtaionType.ScaleToTarget || this.AnimationType == UI_AnimtaionType.MoveToTarget")]
    public Vector2 Target;
}

public static class UI_AnimationHandler
{
    static void Add(Sequence baseSequence, Tweener addAnimation, UI_AnimationInfo animationInfo)
    {
        addAnimation.SetEase(animationInfo.Ease);

        switch(animationInfo.SequenceType)
        {
            case SequenceType.Append:
                baseSequence.Append(addAnimation);
                break;
            case SequenceType.Insert:
                baseSequence.Insert(animationInfo.InsertTime, addAnimation);
                break;
            case SequenceType.Jon:
                baseSequence.Join(addAnimation);
                break;
            default:
                throw new NotImplementedException();
        }
    }

    public static void Apply(Sequence baseSequence, UI_Behaviour target, UI_AnimationInfo animation)
    {
        if (animation.Delay > 0)
            baseSequence.SetDelay(animation.Delay);

        switch (animation.AnimationType)
        {
            case UI_AnimtaionType.None:
                break;
            case UI_AnimtaionType.ScaleToTarget:
                {
                    Add(baseSequence, target.RectTransform.DOScale(animation.Target, animation.Duration), animation);
                }
                break;
            case UI_AnimtaionType.ScaleRatio:
                {
                    Vector3 targetScale = target.RectTransform.localScale * animation.Value;

                    Add(baseSequence, target.RectTransform.DOScale(targetScale, animation.Duration), animation);
                }
                break;
            case UI_AnimtaionType.MoveToTarget:
                {
                    Add(baseSequence, target.RectTransform.DOMoveUI(animation.Target, animation.Duration), animation);
                }
                break;
            case UI_AnimtaionType.RotateToTarget:
                {
                    Add(baseSequence, target.RectTransform.DORotateUI(animation.Value, animation.Duration), animation);
                }
                break;
            default:
                throw new NotImplementedException();
        }
    }

    public static void Apply(Sequence baseSequence, UI_Behaviour target, List<UI_AnimationInfo> animations)
    {
        foreach (var anim in animations)
        {
            Apply(baseSequence, target, anim);
        }
    }
}

[CreateAssetMenu(fileName = "UI_Animation", menuName = "Scriptable Objects/UI/Animation")]
public class UI_Animation : UI_ScriptableObject
{
    [HideInInspector]
    public UnityEvent OnStartAnimationEvent = new UnityEvent();
    [HideInInspector]
    public UnityEvent OnFinishAnimationEvent = new UnityEvent();

    [BoxGroup("Animation")]
    public List<UI_AnimationInfo> Animations = new List<UI_AnimationInfo>();

    Sequence _playingSequence;

    /// <summary>
    /// 애니메이션 실행
    /// </summary>
    public void StartAnimation(UI_Behaviour animationTarget)
    {
        // 실행 중인 애니메이션이 있을 수도 있으니 애니메이션 종료
        FinishAnimation();

        RegisterAnimation(animationTarget);
    }

    /// <summary>
    /// 시퀸스 생성 후 애니메이션 실행
    /// </summary>
    protected void RegisterAnimation(UI_Behaviour animationTarget)
    {
        _playingSequence = DOTween.Sequence();
        _playingSequence.OnStart(OnStartAnimation);
        _playingSequence.OnComplete(OnFinishAnimation);

        UI_AnimationHandler.Apply(_playingSequence, animationTarget, Animations);
    }

    /// <summary>
    /// 애니메이션 종료
    /// </summary>
    public void FinishAnimation()
    {
        if (_playingSequence == null)
            return;

        _playingSequence.Complete(true);
        _playingSequence.Kill();
        _playingSequence = null;
    }

    void OnStartAnimation()
    {
        OnStartAnimationEvent.Invoke();
    }

    void OnFinishAnimation()
    {
        OnFinishAnimationEvent.Invoke();
    }
}
