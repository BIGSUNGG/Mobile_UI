using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public class PopupManager : MonoBehaviour
{
    /// <summary>
    /// 현재 열려 있는 팝업 목록
    /// item1 : 팝업 프리팹
    /// item2 : 열려있는 팝업 컴포넌트
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

        // 팝업 중복 방지
        if (_openedPopup.Where(t=>t.Item1 == popupPrefab).FirstOrDefault() != null)
            return null;

        // 팝업 생성
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

        // 팝업 매니저에서 관리 중인 팝업이 아닌 경우 false 반환
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
