using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class UI_HorizontalLayoutGroup : UI_Unit
{
    [TabGroup("UI")] public HorizontalLayoutGroup LayoutGroup;
    // ���̾ƿ� �׷��� �ڽ� ����� ����Ǵ� �Ϳ� ������ ���� ����
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
            // Child�� ������ �þ�� �� LayoutGroup�� �ٷ� ������ ������ �ۼ��� �ڵ� (���� �� Ŀ�� �ڽ� �ֺ� �ڽĵ��� �з����� ����)
            LayoutRebuilder.MarkLayoutForRebuild(RectTransform);
            LayoutRebuilder.ForceRebuildLayoutImmediate(RectTransform);
        }
    }
}
