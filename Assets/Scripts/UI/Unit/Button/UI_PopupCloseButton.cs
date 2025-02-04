using Sirenix.OdinInspector;
using UnityEngine;

public class UI_PopupClosetButton : UI_Button
{
    [SerializeField, TabGroup("Popup")] UI_Popup _closePopup;

    public override void Awake()
    {
        base.Awake();

        if (_closePopup == null)
            _closePopup = GetComponentInParent<UI_Popup>();
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
        PopupManager.Instance.Close(_closePopup);
    }
}
