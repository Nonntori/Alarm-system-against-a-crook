using UnityEngine;
using UnityEngine.Events;

public class Door: MonoBehaviour
{
    [SerializeField] UnityEvent _movementEnter;
    [SerializeField] UnityEvent _movementLeave;

    private void OnTriggerEnter(Collider other)
    {
        _movementEnter?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        _movementLeave?.Invoke();
    }
}

