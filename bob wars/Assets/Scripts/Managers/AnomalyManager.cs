using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyManager : MonoBehaviour
{
    public static AnomalyManager instance; // For singleton
    [SerializeField] private List<GameObject> _anomalies;

    // Establishing a singleton:
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Function for choosing and applying anomalies
    public void ApplyAnomaly()
    {
        Anomaly chosen = _anomalies[Random.Range(0, _anomalies.Count)].GetComponent<Anomaly>();
        chosen.ApplyAnomaly();
    }
}

public class AnomalyFunctions
{
    public void Test()
    {
        Debug.Log("Test success");
    }
}