using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class UI_Scrollbar : UI_Widget
{
    [TabGroup("UI")] public Image Image;
    [TabGroup("UI")] public Scrollbar Scrollbar;

    public override void Awake()
    {
        base.Awake();

        if (Image == null)
            Image = GetComponent<Image>();

        if (Scrollbar == null)
            Scrollbar = GetComponent<Scrollbar>();
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
