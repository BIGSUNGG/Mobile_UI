using Sirenix.OdinInspector;
using UnityEngine;

public class UI_Canvas : UI_Unit
{
    [TabGroup("UI")] public Canvas Canvas;

    public override void Awake()
    {
        base.Awake();

        if (Canvas == null)
            Canvas = GetComponent<Canvas>();
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }
}
