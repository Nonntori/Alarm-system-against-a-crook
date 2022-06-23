using UnityEngine;
using UnityEngine.Events;

public class Door: MonoBehaviour
{
    [SerializeField] UnityEvent _movementEnter;
    [SerializeField] UnityEvent _movementLeave;

    public static bool IsMovement;

    private void OnTriggerEnter(Collider other)
    {
        IsMovement = true;
        _movementEnter?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        IsMovement = false;
        _movementLeave?.Invoke(); 
    }
}

