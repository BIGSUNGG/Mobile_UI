using UnityEngine;
using UnityEngine.UI;

public class UI_Button : UI_Base
{
    public Image Image { get; private set; }
    public Button Button { get; private set; }

    public override void Awake()
    {
        base.Awake();

        Image = GetComponentInChildren<Image>();
        Button = GetComponentInChildren<Button>();
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

    public virtual void OnClickButton()
    {
        
    }
}
