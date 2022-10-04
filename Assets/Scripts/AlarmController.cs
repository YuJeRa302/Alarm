using System.Collections;
using UnityEngine;

public class AlarmController : MonoBehaviour
{
    [SerializeField] Animator _animator;
    [SerializeField] AudioSource _audioSource;

    private IEnumerator _soundUp;
    private IEnumerator _soundDown;

    private void Start()
    {
        _soundUp = IncreaseSound();
        _soundDown = ReductionSound();
        _audioSource.Play();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<CowboyController>(out CowboyController cowboy))
        {
            StartCoroutine(_soundUp);
            StopCoroutine(_soundDown);
            _animator.SetBool("IsAlarm", true);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<CowboyController>(out CowboyController cowboy))
        {
            StartCoroutine(_soundDown);
            StopCoroutine(_soundUp);
            _animator.SetBool("IsAlarm", false);
        }
    }

    private IEnumerator IncreaseSound()
    {
        while (true)
        {
            _audioSource.volume += Time.deltaTime;
            yield return null;
        }
    }

    private IEnumerator ReductionSound()
    {
        while (true)
        {
            _audioSource.volume -= Time.deltaTime;
            yield return null;
        }
    }
}
