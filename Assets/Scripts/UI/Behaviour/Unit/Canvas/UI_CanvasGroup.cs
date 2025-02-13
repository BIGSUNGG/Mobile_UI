using Sirenix.OdinInspector;
using UnityEngine;

/// <summary>
/// UI에서 SafeArea에 대해 어떻게 처리할지에대한 타입
/// </summary>
public enum SafeAreaProcessType
{
    Nothing,

    // Safe Area를 피해 UI 크기 줄이기
    Avoid,

    // Safe Area의 아래 부분만큼 크기 변경
    FillBottom,
    // Safe Area의 윗 부분만큼 크기 변경
    FillTop,
}

public class UI_CanvasGroup : UI_Unit
{
    [TabGroup("UI")] public CanvasGroup CanvasGroup;

    [SerializeField, TabGroup("Canvas"), Tooltip("핸드폰의 카메라 홀과 같은 것에 UI가 가려지는 것을 어떻게 처리할 것인지")]
    SafeAreaProcessType _safeAreaProcessType = SafeAreaProcessType.Nothing;

    Vector2 _minAnchor;
    Vector2 _maxAnchor;

    public override void Awake()
    {
        base.Awake();

        if (CanvasGroup == null)
            CanvasGroup = GetComponent<CanvasGroup>();
    }

    public override void Start()
    {
        base.Start();

        ProcessSafeArea();
    }

    public override void Update()
    {
        base.Update();

        ProcessSafeArea();
    }

    void ProcessSafeArea()
    {
        _minAnchor = Screen.safeArea.min;
        _maxAnchor = Screen.safeArea.max;

        _minAnchor.x /= Screen.width;
        _minAnchor.y /= Screen.height;

        _maxAnchor.x /= Screen.width;
        _maxAnchor.y /= Screen.height;

        if (_safeAreaProcessType == SafeAreaProcessType.Avoid)
        {
            RectTransform.anchorMin = _minAnchor;
            RectTransform.anchorMax = _maxAnchor;
        }
        else if (_safeAreaProcessType == SafeAreaProcessType.FillBottom)
        {
            RectTransform.anchorMin = Vector2.zero;
            RectTransform.anchorMax = new Vector2(RectTransform.anchorMax.x, _minAnchor.y);
        }
        else if (_safeAreaProcessType == SafeAreaProcessType.FillTop)
        {
            RectTransform.anchorMin = new Vector2(RectTransform.anchorMin.x, _maxAnchor.y);
            RectTransform.anchorMax = Vector2.one;
        }
    }
}
