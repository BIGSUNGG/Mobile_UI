using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MainMenuFooter : UI_Base
{
    [SerializeField, TabGroup("Icon")] List<GameObject> _iconGameObjects = new List<GameObject>();
    List<UI_MainMenuFooterIcon> _icons = new List<UI_MainMenuFooterIcon>();
    [SerializeField, TabGroup("Icon")] int _startIconNum = 2;

    UI_MainMenuFooterIcon _selectedIcon;

    [SerializeField, TabGroup("UI")] GameObject _iconLayoutGameObject;
    HorizontalLayoutGroup _iconLayoutGroup;
    RectTransform _iconLayoutRectTransform;

    public override void Awake()
    {
        base.Awake();

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();

        RectTransform = GetComponent<RectTransform>();
        _iconLayoutGroup = _iconLayoutGameObject.GetComponent<HorizontalLayoutGroup>();
        _iconLayoutRectTransform = _iconLayoutGameObject.GetComponent<RectTransform>();

        foreach (var go in _iconGameObjects)
        {
            UI_MainMenuFooterIcon icon = go.GetComponent<UI_MainMenuFooterIcon>();
            icon.Button.onClick.AddListener(() => { OnClickIcon(icon); });
            _icons.Add(icon);
        }

        SelectIcon(_icons[_startIconNum]);
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        // Icon이 옆으로 늘어났을 때 LayoutGroup에 바로 영향이 가도록 작성한 코드 (제거 시 커진 아이콘 주변 아이콘이 밀려나지 않음)
        LayoutRebuilder.MarkLayoutForRebuild(_iconLayoutRectTransform);
        LayoutRebuilder.ForceRebuildLayoutImmediate(_iconLayoutRectTransform);
    }

    void OnClickIcon(UI_MainMenuFooterIcon clickedIcon)
    {
        SelectIcon(clickedIcon);
    }

    void SelectIcon(UI_MainMenuFooterIcon newSelectedIcon)
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
