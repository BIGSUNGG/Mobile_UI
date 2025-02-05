using DG.Tweening;
using System;
using UnityEngine;

namespace Extensions
{
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

    public static class DOTWeenExtension
    {


    }
}