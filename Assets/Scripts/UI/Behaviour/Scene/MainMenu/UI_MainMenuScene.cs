using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_MainMenuScene : UI_Scene
{
    [SerializeField, TabGroup("Shop")] UI_Button _shopButton;
    [SerializeField, TabGroup("Shop")] UI_Canvas _shopCanvas;

    [SerializeField, TabGroup("Equip")] UI_Button _equipButton;
    [SerializeField, TabGroup("Equip")] UI_Canvas _equipCanvas;

    [SerializeField, TabGroup("Advanture")] UI_Button _advantureButton;
    [SerializeField, TabGroup("Advanture")] UI_Canvas _advantureCanvas;
    [SerializeField, TabGroup("Advanture")] UI_Button _gameStartButton;

    [SerializeField, TabGroup("Status")] UI_Button _statusButton;
    [SerializeField, TabGroup("Status")] UI_Canvas _statusCanvas;

    [SerializeField, TabGroup("Chest")] UI_Button _chestButton;
    [SerializeField, TabGroup("Chest")] UI_Canvas _chestCanvas;

    UI_Button _selectedButton;

    public override void Awake()
    {
        base.Awake();

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public override void Start()
    {
        base.Start();

        _shopButton.Button.onClick.AddListener(OnClickShopButton);
        _equipButton.Button.onClick.AddListener(OnClickEquiptButton);
        _advantureButton.Button.onClick.AddListener(OnClickAdvantureButton);
        _statusButton.Button.onClick.AddListener(OnClickStatusButton);
        _chestButton.Button.onClick.AddListener(OnClickChestButton);

        _gameStartButton.Button.onClick.AddListener(OnClickGameStartButton);

        OnClickAdvantureButton();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();

    }

    #region Game
    void OnClickGameStartButton()
    {
        SceneManager.LoadScene("BackGroundTest");
    }
    #endregion

    #region Icon
    void OnClickShopButton()
    {
        DeactivateAllIconCanvas();
        _shopCanvas.gameObject.SetActive(true);

        SetSelectIcon(_shopButton);
    }

    void OnClickEquiptButton()
    {
        DeactivateAllIconCanvas();
        _equipCanvas.gameObject.SetActive(true);

        SetSelectIcon(_equipButton);
    }

    void OnClickAdvantureButton()
    {
        DeactivateAllIconCanvas();
        _advantureCanvas.gameObject.SetActive(true);

        SetSelectIcon(_advantureButton);
    }

    void OnClickStatusButton()
    {
        DeactivateAllIconCanvas();
        _statusCanvas.gameObject.SetActive(true);

        SetSelectIcon(_statusButton);
    }

    void OnClickChestButton()
    {
        DeactivateAllIconCanvas();
        _chestCanvas.gameObject.SetActive(true);

        SetSelectIcon(_chestButton);
    }

    /// <summary>
    /// 현재 선택된 아이콘 버튼 설정
    /// </summary>
    /// <param name="newSelectedIcon">선택된 버튼</param>
    void SetSelectIcon(UI_Button newSelectedButton)
    {
        if (_selectedButton == newSelectedButton)
            return;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(newSelectedButton.RectTransform.DOSizeDelta(new Vector2(360.0f, 180.0f), 0.1f));
        sequence.Join(newSelectedButton.Button.GetComponent<RectTransform>().DOSizeDelta(new Vector2(360.0f, 180.0f), 0.1f));
        if (_selectedButton)
        {
            sequence.Join(_selectedButton.RectTransform.DOSizeDelta(new Vector2(180.0f, 180.0f), 0.1f));
            sequence.Join(_selectedButton.Button.GetComponent<RectTransform>().DOSizeDelta(new Vector2(180.0f, 180.0f), 0.1f));
        }

        _selectedButton = newSelectedButton;
    }

    /// <summary>
    /// 모든 아이콘 오브젝트 안보이도록
    /// </summary>
    void DeactivateAllIconCanvas()
    {
        _shopCanvas.gameObject.SetActive(false);
        _equipCanvas.gameObject.SetActive(false);
        _advantureCanvas.gameObject.SetActive(false);
        _statusCanvas.gameObject.SetActive(false);
        _chestCanvas.gameObject.SetActive(false);
    }
    #endregion
}
