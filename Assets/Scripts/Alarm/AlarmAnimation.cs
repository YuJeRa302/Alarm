using UnityEngine;

public class AlarmAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private Trigger _trigger;

    enum TransitionParametr
    {
        IsAlarm
    }

    private void OnEnable()
    {
        _trigger = FindObjectOfType<Trigger>();
        _trigger.TriggerEnter += TriggerEnter;
    }

    private void TriggerEnter()
    {
        var transitionParametr = Animator.StringToHash(TransitionParametr.IsAlarm.ToString());
        _animator.SetBool(transitionParametr, _trigger.IsTriggerEnter);
    }
}
