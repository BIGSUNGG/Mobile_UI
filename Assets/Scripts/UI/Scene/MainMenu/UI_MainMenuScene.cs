using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MainMenuScene : UI_Scene
{
    [SerializeField, TabGroup("Icon")] List<UI_Button> _icons = new List<UI_Button>();
    [SerializeField, TabGroup("Icon")] int _startIconNum = 2;

    UI_Button _selectedIcon;

    public override void Awake()
    {
        base.Awake();

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();

        RectTransform = GetComponent<RectTransform>();

        foreach (var icon in _icons)
            icon.Button.onClick.AddListener(() => { OnClickIcon(icon); });

        SelectIcon(_icons[_startIconNum]);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

    }

    void OnClickIcon(UI_Button clickedIcon)
    {
        SelectIcon(clickedIcon);
    }

    void SelectIcon(UI_Button newSelectedIcon)
    {
        if (_selectedIcon == newSelectedIcon)
            return;

        Sequence mysquence = DOTween.Sequence();
        mysquence.Append(newSelectedIcon.RectTransform.DOSizeDelta(new Vector2(360.0f, 180.0f), 0.1f));
        mysquence.Join(newSelectedIcon.Button.GetComponent<RectTransform>().DOSizeDelta(new Vector2(360.0f, 180.0f), 0.1f));
        if (_selectedIcon)
        {
            mysquence.Join(_selectedIcon.RectTransform.DOSizeDelta(new Vector2(180.0f, 180.0f), 0.1f));
            mysquence.Join(_selectedIcon.Button.GetComponent<RectTransform>().DOSizeDelta(new Vector2(180.0f, 180.0f), 0.1f));
        }

        _selectedIcon = newSelectedIcon;
    }
}
