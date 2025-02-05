using DG.Tweening;
using System;
using UnityEngine;

namespace Extensions
{
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

    public static class DOTWeenExtension
    {


    }
}