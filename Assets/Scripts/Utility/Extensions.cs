using DG.Tweening;
using System;
using UnityEngine;

public static class ScriptableObjectExtension
{
    /// <summary>
    /// �����Ǵ� ScriptableObject�� �������� ��ü�� ����
    /// </summary>
    /// <param name="scriptableObject">������ ScriptableObject</param>
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


}