using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _triggerEnter = new UnityEvent();

    private Alarm _alarm;

    public event UnityAction TriggerEnter
    {
        add => _triggerEnter.AddListener(value);
        remove => _triggerEnter.RemoveListener(value);
    }

    public bool IsTriggerEnter { get; private set; }

    private void Awake()
    {
        _alarm = FindObjectOfType<Alarm>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<CowboyController>(out CowboyController cowboy))
        {
            IsTriggerEnter = true;
            _triggerEnter.Invoke();
            _alarm.ChangeSound(IsTriggerEnter);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<CowboyController>(out CowboyController cowboy))
        {
            IsTriggerEnter = false;
            _triggerEnter.Invoke();
            _alarm.ChangeSound(IsTriggerEnter);
        }
    }
}
