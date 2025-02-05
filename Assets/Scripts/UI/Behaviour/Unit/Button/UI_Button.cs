using Sirenix.OdinInspector;
using Sirenix.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class UI_Button : UI_Unit
{
    [TabGroup("UI")] public Image Image;
    [TabGroup("UI")] public Button Button;

    public override void Awake()
    {
        base.Awake();

        if(Image == null)
            Image = GetComponent<Image>();

        if (Button == null)
            Button = GetComponent<Button>();

        Button.onClick.AddListener(OnClickButton);
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    protected virtual void OnClickButton()
    {
        
    }
}
