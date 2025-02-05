using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class UI_HpBarWidget : UI_Widget
{
    [TabGroup("UI"), Tooltip("현재 체력을 보여주는 스크롤바")]
    public UI_Image CurremtHpBar;
    [TabGroup("UI"), Tooltip("데미지가 닳은 정도를 보여주며 천천히 사라지는 스크롤바")]
    public UI_Image DelayedHpBar;

    Sequence _delayHpBarAnimSequence = null;

    // 임시 코드
    float _maxHp = 100;
    float _currentHp = 100;

    public override void Awake()
    {
        base.Awake();

        if (CurremtHpBar == null)
            Debug.LogError("CurrentHpBar is null");

        if (DelayedHpBar == null)
            Debug.LogError("DelayedHpBar is null");
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    public void TakeDamage(float damage)
    {
        if (_delayHpBarAnimSequence != null)
        {
            _delayHpBarAnimSequence.Complete();

            float prevHpRatio = _currentHp / _maxHp;
            DelayedHpBar.Image.fillAmount = prevHpRatio;
        }

        _currentHp -= damage;
        if (_currentHp < 0)
            _currentHp = 0;

        float hpRatio = _currentHp / _maxHp;

        CurremtHpBar.Image.fillAmount = hpRatio;

        _delayHpBarAnimSequence = DOTween.Sequence();
        _delayHpBarAnimSequence.Append(DOTween.To(() => DelayedHpBar.Image.fillAmount, x => DelayedHpBar.Image.fillAmount = x, hpRatio, 0.75f).SetEase(Ease.OutCubic));
    }

    public void TakeHeal(float heal)
    {
        if (_delayHpBarAnimSequence != null)
            _delayHpBarAnimSequence.Kill();

        _currentHp += heal;
        if (_currentHp > _maxHp)
            _currentHp = _maxHp;

        float hpRatio = _currentHp / _maxHp;

        CurremtHpBar.Image.fillAmount = hpRatio;
        DelayedHpBar.Image.fillAmount = hpRatio;
    }
}
