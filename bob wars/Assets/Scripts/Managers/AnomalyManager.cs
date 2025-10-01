using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyManager : MonoBehaviour
{
    public static AnomalyManager instance; // For singleton
    [SerializeField] private GameObject _disappearObject;
    [SerializeField] private GameObject _biggerObject;

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
    public void ApplyAnomaly1()
    {
        int count = 2;
        // Anomaly chosen = _anomalies[Random.Range(0, cou)].GetComponent<Anomaly>();

        int rand = Random.Range(0, count);
        Debug.Log(rand);
        if (rand == 0) // Disappear
        {
            Disappear();
        }
        else if (rand == 1) // Big
        {
            theOtherThing();
        }

        // Debug.Log(chosen);
        // chosen.ApplyAnomaly();
    }





    // Functions
    public void Disappear()
    {
        _disappearObject.SetActive(false);
    }
    public void theOtherThing(GameObject obj)
    {
        _biggerObject.transform.localScale = new Vector3(10, 10, 10);
    }
}