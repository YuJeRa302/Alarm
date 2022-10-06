using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private IEnumerator _sound—hange;

    private void Start()
    {
        _audioSource.Play();
    }

    public void ChangeSound(bool isTriggerEnter)
    {
        if (_sound—hange != null)
        {
            StopCoroutine(_sound—hange);
            _sound—hange = —hangeVolume(isTriggerEnter);
            StartCoroutine(_sound—hange);
        }
        else
        {
            _sound—hange = —hangeVolume(isTriggerEnter);
            StartCoroutine(_sound—hange);
        }
    }

    private IEnumerator —hangeVolume(bool isChagenVolume)
    {
        while (true)
        {
            if (isChagenVolume == true)
            {
                _audioSource.volume += Time.deltaTime;
            }
            else
            {
                _audioSource.volume -= Time.deltaTime;
            }

            yield return null;
        }
    }
}
