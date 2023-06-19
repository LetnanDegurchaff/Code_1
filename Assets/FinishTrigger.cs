using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    private List<Trigger> _triggers;

    private void OnEnable()
    {
        _triggers = gameObject.GetComponentsInChildren<Trigger>().ToList();

        foreach (var trigger in _triggers)
        {
            trigger.Event += OnTriggerEvented;
        }
    }

    private void OnDisable()
    {
        foreach (var trigger in _triggers)
        {
            trigger.Event -= OnTriggerEvented;
        }
    }

    private void OnTriggerEvented()
    {
        foreach (var trigger in _triggers)
            if (trigger.IsTriggered == false)
                return;

        Debug.Log("All triggers reached");
    }
}
