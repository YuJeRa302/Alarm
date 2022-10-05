using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private Trigger _trigger;

    private IEnumerator _soundEnable;
    private IEnumerator _soundDisable;

    private void Start()
    {
        _soundEnable = IncreaseSound();
        _soundDisable = ReductionSound();
        _audioSource.Play();
    }

    private void OnEnable()
    {
        _trigger = FindObjectOfType<Trigger>();
        _trigger.TriggerEnter += TriggerEnter;
    }

    private void TriggerEnter()
    {
        if (_trigger.IsTriggerEnter == true)
        {
            if (_soundDisable != null)
            {
                StopCoroutine(_soundDisable);
                StartCoroutine(_soundEnable);
            }
        }
        else
        {
            if (_soundEnable != null)
            {
                StopCoroutine(_soundEnable);
                StartCoroutine(_soundDisable);
            }
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
