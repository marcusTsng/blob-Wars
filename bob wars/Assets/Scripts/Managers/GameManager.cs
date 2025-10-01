using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int level = 0;
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

    private void Start()
    {
        AnomalyManager.instance.ApplyAnomaly1();
    }

    // PUBLIC FUNCTIONS
    public void NextLevel()
    {
        level += 1;
    }
}
