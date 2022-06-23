using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _activeCoroutine;
    private float _recoveryRate = 0.5f;
    private float _requiredValue;

    public void Play()
    {
        if (Door.IsMovement)
        {
            _audioSource.Play();
            _activeCoroutine = StartCoroutine(TakeChangeSoundVolume());
        }
        else
        {
            StopCoroutine(_activeCoroutine);
            _activeCoroutine = StartCoroutine(TakeChangeSoundVolume());
        }
    }

    private void Start()
    {
        _audioSource.volume = 0;
    }

    private IEnumerator TakeChangeSoundVolume()
    {
        if (Door.IsMovement)
        {
            _requiredValue = 1f;
        }
        else
        {
            _requiredValue = 0f;
        }

        while (_audioSource.volume != _requiredValue)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _requiredValue, _recoveryRate * Time.deltaTime);
            yield return null;
        }
    }
}
