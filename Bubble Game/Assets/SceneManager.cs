using System;
using Unity.Mathematics;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public static SceneManager instance;
    public int currentDifficulty = 1;
    [SerializeField] private int currentDay = 1;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    public void ChangeDay()
    {
        // Lowers or raises difficulty
        if(ScoringSystem.instance.dailyScore < 0)
        {
            LowerDifficulty();
        }
        else
        {
            RaiseDifficulty();
        }
        ScoringSystem.instance.dailyScore = 0;


        //Change Scene
    }

    private void RaiseDifficulty()
    {
        currentDifficulty++;
        currentDifficulty = Math.Clamp(currentDifficulty, 1, 5);
    }

    private void LowerDifficulty()
    {
        currentDifficulty++;
        currentDifficulty = Math.Clamp(currentDifficulty, 1, 5);
    }


} 
