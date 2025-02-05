using UnityEngine.EventSystems;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

public class UI_Behaviour : MonoBehaviour
{
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
}
