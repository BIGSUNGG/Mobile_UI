using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ScrollingInfo
{
    [Tooltip("배경 오브젝트의 트랜스폼")]
    public Transform Transform;
    [Tooltip("가장 앞에있는 배경이 되었을 때 얼마 뒤에 가장 뒤로 넘어갈지")]
    public float RepeatTime;

    public Vector3 RepeatPos { get; set; }
}

public class BackgroundScrolling : Background
{
    public UnityEvent<ScrollingInfo> OnRepeatBackgroundEvent { get; set; } = new UnityEvent<ScrollingInfo>();

    [SerializeField, TabGroup("Scrolling"), Tooltip("배경이 움직이는 속도")]
    float _speed;
    [SerializeField, TabGroup("Scrolling"), Tooltip("배경이 움직이는 방향")]
    Vector2 _direction;

    [SerializeField, TabGroup("Scrolling"), Tooltip("배경 정보 배열")]
    List<ScrollingInfo> _infos = new List<ScrollingInfo>();

    [ShowInInspector, ReadOnly, TabGroup("Scrolling"), Tooltip("가장 앞에 있는 배경이 가장 뒤로갈 때까지 남은 시간")]
    float _remainingRepeatTime = 0.0f;

    public override void Awake()
    {
        base.Awake();

    }

    public override void Start()
    {
        base.Start();

        _direction.Normalize();
        _remainingRepeatTime = _infos.First().RepeatTime;

        // 배경이 반복될 때까지 얼마나 이동하는지
        Vector3 howMoveUntilRepeat = Vector3.zero;
        foreach(var info in _infos)
        {
            howMoveUntilRepeat += (_direction * _speed * info.RepeatTime).ToVector3();
        }

        foreach (var info in _infos)
        {
            howMoveUntilRepeat -= (_direction * _speed * info.RepeatTime).ToVector3();
            info.RepeatPos = info.Transform.position - howMoveUntilRepeat;
        }
    }

    public override void Update()
    {
        base.Update();

        _remainingRepeatTime -= Time.deltaTime;
        if (_remainingRepeatTime <= 0)
        {
            RepeatBackground();
            OnRepeatBackground(_infos.First());
        }

        Vector3 moveDelta = _direction * _speed * Time.deltaTime;

        foreach (var background in _infos)
        {
            background.Transform.position += moveDelta;
        }
    }   

    void RepeatBackground()
    {
        // 가장 앞에 있는 배경을 가장 뒤로 넘기기
        var firstInfo = _infos.First();

        firstInfo.Transform.position = firstInfo.RepeatPos;
      
        // 리스트의 가장 앞에 있는 정보를 가장 뒤로 넘기기
        _infos.RemoveAt(0);
        _infos.Add(firstInfo);

        // 가장 앞에 있는 배경의 가장 뒤로가는 시간 설정
        _remainingRepeatTime += _infos.First().RepeatTime;
    }

    void OnRepeatBackground(ScrollingInfo info)
    {
        OnRepeatBackgroundEvent.Invoke(info);
    }
}
