using UnityEngine;
using UnityEngine.UI;

public class UI_MainMenuFooterIcon : UI_Base
{
    public Image Image { get; private set; }
    public Button Button { get; private set; }

    public override void Awake()
    {
        base.Awake();

        Image = GetComponentInChildren<Image>();
        Button = GetComponentInChildren<Button>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();

        RectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

        LayoutRebuilder.ForceRebuildLayoutImmediate(RectTransform);
    }
}
