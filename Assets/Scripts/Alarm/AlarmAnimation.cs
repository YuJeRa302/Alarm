using UnityEngine;

public class AlarmAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Trigger _trigger;

    enum TransitionParametr
    {
        IsAlarm
    }

    private void OnEnable()
    {
        _trigger.TriggerEnter += TriggerEnter;
    }

    private void TriggerEnter()
    {
        var transitionParametr = Animator.StringToHash(TransitionParametr.IsAlarm.ToString());
        _animator.SetBool(transitionParametr, _trigger.IsTriggerEnter);
    }
}
