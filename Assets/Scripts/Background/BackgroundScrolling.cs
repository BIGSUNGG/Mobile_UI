using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ScrollingInfo
{
    [Tooltip("��� ������Ʈ�� Ʈ������")]
    public Transform Transform;
    [Tooltip("����� ����")]
    public float Interval;

    public float RepeatTime { get; set; }

    public Vector3 RepeatPos { get; set; }
}

public class BackgroundScrolling : Background
{
    public UnityEvent<ScrollingInfo> OnRepeatBackgroundEvent { get; set; } = new UnityEvent<ScrollingInfo>();

    [SerializeField, TabGroup("Scrolling"), Tooltip("����� �����̴� �ӵ�")]
    float _speed;
    [SerializeField, TabGroup("Scrolling"), Tooltip("����� �����̴� ����")]
    Vector2 _direction;

    [SerializeField, TabGroup("Scrolling"), Tooltip("��� ���� �迭")]
    List<ScrollingInfo> _infos = new List<ScrollingInfo>();

    [ShowInInspector, ReadOnly, TabGroup("Scrolling"), Tooltip("���� �տ� �ִ� ����� ���� �ڷΰ� ������ ���� �ð�")]
    float _remainingRepeatTime = 0.0f;

    public override void Awake()
    {
        base.Awake();
        
        foreach(var info in _infos)
        {
            info.RepeatTime = info.Interval / _speed;
        }

        _direction.Normalize();
        _remainingRepeatTime = _infos.First().RepeatTime;

        // ����� �ݺ��� ������ �󸶳� �̵��ϴ���
        Vector3 howMoveUntilRepeat = Vector3.zero;
        foreach (var info in _infos)
        {
            howMoveUntilRepeat += (_direction * _speed * info.RepeatTime).ToVector3();
        }

        foreach (var info in _infos)
        {
            howMoveUntilRepeat -= (_direction * _speed * info.RepeatTime).ToVector3();
            info.RepeatPos = info.Transform.position - howMoveUntilRepeat;
        }
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();

        // ��� �̵�
        Vector3 moveDelta = _direction * _speed * Time.deltaTime;
        foreach (var background in _infos)
        {
            background.Transform.position += moveDelta;
        }

        // ���� �տ� �ִ� ����� ���� �ڷ� �������� ���� �ð� ���ϱ�
        _remainingRepeatTime -= Time.deltaTime;
        if (_remainingRepeatTime <= 0)
            RepeatBackground();
    }   

    void RepeatBackground()
    {
        // ���� �տ� �ִ� ����� ���� �ڷ� �ѱ��
        var firstInfo = _infos.First();

        firstInfo.Transform.position = firstInfo.RepeatPos - (_direction * _speed * _remainingRepeatTime).ToVector3();

        // ����Ʈ�� ���� �տ� �ִ� ������ ���� �ڷ� �ѱ��
        _infos.RemoveAt(0);
        _infos.Add(firstInfo);

        // ���� �տ� �ִ� ����� ���� �ڷΰ��� �ð� ����
        _remainingRepeatTime += _infos.First().RepeatTime;

        OnRepeatBackground(_infos.First());
    }

    void OnRepeatBackground(ScrollingInfo info)
    {
        OnRepeatBackgroundEvent.Invoke(info);
    }
}
