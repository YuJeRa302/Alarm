using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _triggerEnter = new UnityEvent();

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
            _triggerEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<CowboyController>(out CowboyController cowboy))
        {
            IsTriggerEnter = false;
            _triggerEnter.Invoke();
        }
    }
}
