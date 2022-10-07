using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _triggerEnter = new UnityEvent();
    [SerializeField] private Alarm _alarm;

    public event UnityAction TriggerEnter
    {
        add => _triggerEnter.AddListener(value);
        remove => _triggerEnter.RemoveListener(value);
    }

    public bool IsTriggerEnter { get; private set; }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<CowboyController>(out CowboyController cowboy))
        {
            IsTriggerEnter = true;
            float target = IsTriggerEnter ? 1 : 0;
            _triggerEnter.Invoke();
            _alarm.ChangeSound(target);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<CowboyController>(out CowboyController cowboy))
        {
            IsTriggerEnter = false;
            float target = IsTriggerEnter ? 1 : 0;
            _triggerEnter.Invoke();
            _alarm.ChangeSound(target);
        }
    }
}
