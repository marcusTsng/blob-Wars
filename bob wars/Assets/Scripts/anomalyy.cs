using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class anomalyy : MonoBehaviour
{
    public UnityEvent<GameObject> e; 
    public void ApplyAnomaly()
    {
        e.Invoke(gameObject);
    }
}
