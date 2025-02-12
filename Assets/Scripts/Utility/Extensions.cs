using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using System;
using UnityEngine;

public static class ScriptableObjectExtension
{
    /// <summary>
    /// 공유되는 ScriptableObject를 독립적인 객체로 변경
    /// </summary>
    /// <param name="scriptableObject">변경할 ScriptableObject</param>
    public static void DetachReference(this ScriptableObject scriptableObject)
    {
        scriptableObject = UnityEngine.Object.Instantiate(scriptableObject);
    }
}

public static class VectorExtension
{
    public static Vector3 ToVector3(this Vector2 vector)
    {
        return new Vector3(vector.x, vector.y, 0);
    }

    public static Vector2 ToVector2(this Vector3 vector)
    {
        return new Vector2(vector.x, vector.y);
    }
}

public static class DOTWeenExtension
{
    public static TweenerCore<Vector3,Vector3,VectorOptions> DOMoveUI(this RectTransform rect, Vector3 target, float time)
    {
        return rect.DOLocalMove(target, time);        
    }

    public static TweenerCore<Quaternion, Vector3, QuaternionOptions> DORotateUI(this RectTransform rect, float target, float time)
    {
        Vector3 targetAngle = rect.localEulerAngles;
        targetAngle.z = target;

        return rect.DOLocalRotate(targetAngle, time);
    }
}