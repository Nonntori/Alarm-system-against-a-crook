using UnityEngine;
using UnityEngine.Events;

public class Door: MonoBehaviour
{
    [SerializeField] private UnityEvent _movementEnter;
    [SerializeField] private UnityEvent _movementLeave;

    public void OnTriggerEnter()
    {
        _movementEnter?.Invoke();
    }

    private void OnTriggerExit()
    {
        _movementLeave?.Invoke(); 
    }
}

