using Sirenix.OdinInspector;
using UnityEngine;

public class UI_PopupOpenButton : UI_Button
{
    [SerializeField, TabGroup("Popup")] GameObject _openPopup;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    protected override void OnClickButton()
    {
        PopupManager.Instance.Open(_openPopup);
    }
}
