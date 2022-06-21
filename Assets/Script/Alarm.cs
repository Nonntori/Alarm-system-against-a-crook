using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    //[SerializeField] private AudioSource _audioSource;
    private AudioSource _audioSource;
    private Coroutine _coroutine;
    private float _recoveryRate = 0.5f;
    private float _maximumVolume = 1f;
    private float _minimumVolume = 0f;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private IEnumerator FadeIn()
    {
        _audioSource.Play();
        _audioSource.volume = _minimumVolume;

        while (_audioSource.volume < _maximumVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _maximumVolume, _recoveryRate * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {
        _audioSource.Play();

        while (_audioSource.volume > _minimumVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _minimumVolume, _recoveryRate * Time.deltaTime);
            yield return null;
        }

        _audioSource.Stop();
    }

    public void Enable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
            
        _coroutine = StartCoroutine(FadeIn());
    }

    public void Disable()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(FadeOut());
    }

}
