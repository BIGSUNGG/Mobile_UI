using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class UI_HorizontalLayoutGroup : UI_Unit
{
    [TabGroup("UI")] public HorizontalLayoutGroup LayoutGroup;
    // 레이아웃 그룹의 자식 사이즈가 변경되는 것에 영향을 받을 것인
    [SerializeField, TabGroup("UI")] bool _isEffectedChildSize = false;

    public override void Awake()
    {
        base.Awake();

        if (LayoutGroup == null)
            LayoutGroup = GetComponent<HorizontalLayoutGroup>();
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();

        if (_isEffectedChildSize)
        {
            // Child가 옆으로 늘어났을 때 LayoutGroup에 바로 영향이 가도록 작성한 코드 (제거 시 커진 자식 주변 자식들이 밀려나지 않음)
            LayoutRebuilder.MarkLayoutForRebuild(RectTransform);
            LayoutRebuilder.ForceRebuildLayoutImmediate(RectTransform);
        }
    }
}
