using Sirenix.OdinInspector;
using UnityEngine;

/// <summary>
/// UI���� SafeArea�� ���� ��� ó������������ Ÿ��
/// </summary>
public enum SafeAreaProcessType
{
    Nothing,

    // Safe Area�� ���� UI ũ�� ���̱�
    Avoid,

    // Safe Area�� �Ʒ� �κи�ŭ ũ�� ����
    FillBottom,
    // Safe Area�� �� �κи�ŭ ũ�� ����
    FillTop,
}

public class UI_CanvasGroup : UI_Unit
{
    [TabGroup("UI")] public CanvasGroup CanvasGroup;

    [SerializeField, TabGroup("Canvas"), Tooltip("�ڵ����� ī�޶� Ȧ�� ���� �Ϳ� UI�� �������� ���� ��� ó���� ������")]
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
