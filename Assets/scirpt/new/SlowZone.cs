using UnityEngine;
using System.Collections.Generic;
using System.Collections;
public class SlowZone : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent onTriggerEnter;
    void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke();
    }

    public UnityEngine.Events.UnityEvent onTriggerExit;
    void OnTriggerExit(Collider other)
    {
        onTriggerExit.Invoke();
    }
}
