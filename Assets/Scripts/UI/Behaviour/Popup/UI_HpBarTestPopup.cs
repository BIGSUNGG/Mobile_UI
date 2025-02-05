using Sirenix.OdinInspector;
using UnityEngine;

public class UI_HpBarTestPopup : UI_Popup
{
    [TabGroup("UI")] public UI_HpBarWidget HpBar;
    [TabGroup("UI")] public UI_Button HpIncreaseButton;
    [TabGroup("UI")] public UI_Button HpDecreaseButton;


    public override void Awake()
    {
        base.Awake();

        if (HpBar == null)
            Debug.LogError("HpBar is null");

        if (HpIncreaseButton == null)
            Debug.LogError("HpIncreaseButton is null");

        if (HpDecreaseButton == null)
            Debug.LogError("HpDecreaseButton is null");

        HpIncreaseButton.Button.onClick.AddListener(OnClickIncreaseButton);
        HpDecreaseButton.Button.onClick.AddListener(OnClickDecreaseButton);
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    void OnClickIncreaseButton()
    {
        HpBar.TakeHeal(25);
    }

    void OnClickDecreaseButton()
    {
        HpBar.TakeDamage(25);
    }
}
