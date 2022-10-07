using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private IEnumerator _volumeChange;
    private float _speed = 0.2f;

    private void Start()
    {
        _audioSource.Play();
    }

    public void ChangeSound(float target)
    {
        if (_volumeChange != null)
        {
            StopCoroutine(_volumeChange);
            _volumeChange = ChangeVolume(target);
            StartCoroutine(_volumeChange);
        }
        else
        {
            _volumeChange = ChangeVolume(target);
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
