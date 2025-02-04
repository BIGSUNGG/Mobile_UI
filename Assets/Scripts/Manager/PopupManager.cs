using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public class PopupManager : MonoBehaviour
{
    /// <summary>
    /// ���� ���� �ִ� �˾� ���
    /// item1 : �˾� ������
    /// item2 : �����ִ� �˾� ������Ʈ
    /// </summary>
    LinkedList<Tuple<GameObject, UI_Popup>> _openedPopup = new LinkedList<Tuple<GameObject, UI_Popup>>();

    public static PopupManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject();
                go.name = "PopupManager";
                _instance = go.AddComponent<PopupManager>();
                DontDestroyOnLoad(go);
            }

            return _instance;
        }
    }

    private static PopupManager _instance;

    public void Awake()
    {
        
    }

    public void Start()
    {
        
    }

    public void Update()
    {
        
    }

    public UI_Popup Open(GameObject popupPrefab, bool immediately = false)
    {
        return Open<UI_Popup>(popupPrefab);
    }

    public T Open<T>(GameObject popupPrefab, bool immediately = false) where T : UI_Popup
    {
        if(popupPrefab == null)            
            return null;

        // �˾� �ߺ� ����
        if (_openedPopup.Where(t=>t.Item1 == popupPrefab).FirstOrDefault() != null)
            return null;

        // �˾� ����
        GameObject go = Instantiate(popupPrefab);
        T popup = go.GetComponent<T>();
        if(popup == null)
        {
            Debug.LogError($"Failed to open popup, {AssetDatabase.GetAssetPath(popupPrefab)} prefab has no {typeof(T).Name} component");
            return null;
        }

        popup.Open();
        _openedPopup.AddLast(new Tuple<GameObject, UI_Popup>(popupPrefab, popup));

        return popup;
    }

    public bool Close(UI_Popup closePopup, bool immediately = false)
    {
        if (closePopup == null)
            return false;

        closePopup.OnFinishCloseAnimationEvent.AddListener(OnFinishPopupCloseAnim);
        closePopup.Close();

        // �˾� �Ŵ������� ���� ���� �˾��� �ƴ� ��� false ��ȯ
        var exist = _openedPopup.Where(t => t.Item2 == closePopup).FirstOrDefault();
        if (exist == null)
            return false;

        _openedPopup.Remove(exist);

        return true;
    }

    void OnFinishPopupCloseAnim(UI_Popup popup)
    {
        Destroy(popup.gameObject);
    }
} 
