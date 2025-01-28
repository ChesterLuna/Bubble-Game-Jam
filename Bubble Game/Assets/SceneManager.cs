using System;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public static ScenesManager instance;
    public int currentDifficulty = 1;
    [SerializeField] public int currentDay = 1;
    [SerializeField] Scene[] scenes;
    

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

    // private void Start()
    // {
    //     SetDayText();
    // }

    // private void SetDayText()
    // {
    //     dayText.text = "Day " + currentDay.ToString();
    // }

    public void ChangeDay()
    {
        // Lowers or raises difficulty
        if(ScoringSystem.instance.PassedDaily())
        {
            LowerDifficulty();
        }
        else
        {
            RaiseDifficulty();
        }
        ScoringSystem.instance.dailyScore = 0;


        //Change Scene
        currentDay++;
        SceneManager.LoadScene(scenes[currentDay].name);
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
