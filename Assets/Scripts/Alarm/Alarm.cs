using System.Collections;
using UnityEngine;
using System;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private IEnumerator _volumeChange;
    private float _speed = 0.2f;

    private void Start()
    {
        _audioSource.Play();
    }

    public void ChangeSound(bool IsTriggerEnter)
    {
        if (_volumeChange != null)
        {
            StopCoroutine(_volumeChange);
            _volumeChange = ChangeVolume(Convert.ToInt32(IsTriggerEnter));
            StartCoroutine(_volumeChange);
        }
        else
        {
            if (_volumeChange != null)
            {
                StopCoroutine(_volumeChange);
            }

            _volumeChange = ChangeVolume(Convert.ToInt32(IsTriggerEnter));
            StartCoroutine(_volumeChange);
        }
    }

    private IEnumerator ChangeVolume(float target)
    {
        while (_audioSource.volume != target)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, _speed * Time.deltaTime);
            yield return null;
        }
    }
}
