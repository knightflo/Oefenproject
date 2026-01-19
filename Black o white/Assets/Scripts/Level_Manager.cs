using System;
using UnityEngine;

public class Level_Manager : MonoBehaviour
{
    public static Level_Manager instance { get; private set; }

    private float level = 0;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void FinishLevel()
    {
        level++;
        Debug.Log("finished level!");
    }
}
