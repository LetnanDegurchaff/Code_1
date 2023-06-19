using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _event = new UnityEvent();

    public event UnityAction Event
    {
        add => _event.AddListener(value);
        remove => _event.RemoveListener(value);
    }

    public bool IsTriggered { get; private set; } = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (IsTriggered) return;

        if (collision.TryGetComponent<Player>(out Player player))
        {
            IsTriggered = true;
            _event.Invoke();
        }
    }
}
