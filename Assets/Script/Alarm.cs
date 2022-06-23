using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _activeCoroutine;
    private float _recoveryRate = 0.5f;
    private float _requiredValue;

    public void PlaySound()
    {
        _requiredValue = 1f;
        _audioSource.Play();
        _activeCoroutine = StartCoroutine(ChangeVolume());
    }

    public void StopSound()
    {
        _requiredValue = 0f;
        StopCoroutine(_activeCoroutine);
        _activeCoroutine = StartCoroutine(ChangeVolume());
    }

    private void Start()
    {
        _audioSource.volume = 0;
    }

    private IEnumerator ChangeVolume()
    {
        while (_audioSource.volume != _requiredValue)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _requiredValue, _recoveryRate * Time.deltaTime);
            yield return null;
        }
    }
}
