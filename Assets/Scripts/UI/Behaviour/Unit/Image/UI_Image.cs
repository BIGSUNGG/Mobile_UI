using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class UI_Image : UI_Unit
{
    [TabGroup("UI")] public Image Image;

    public override void Awake()
    {
        base.Awake();

        if (Image == null)
            Image = GetComponent<Image>();
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    public virtual void OnClickButton()
    {

    }
}
