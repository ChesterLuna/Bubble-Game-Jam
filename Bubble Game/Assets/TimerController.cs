using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    private TextMeshProUGUI textComponent = null;
    [SerializeField] GameObject levelManager;

    private void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
        levelManager = GameObject.FindGameObjectWithTag("GameController");
    }

    private void Update()
    {
        textComponent.text = ConvertToMinutes(levelManager.GetComponent<Timer>().timeLeft);
    }

    private string ConvertToMinutes(float seconds)
    {
        if(seconds < 0) return "0:00";
        int minutesLeft = Mathf.FloorToInt(seconds/60f);
        int secondsLeft = Mathf.FloorToInt(seconds - minutesLeft * 60f);
        string timerFormat = string.Format("{0:0}:{1:00}", minutesLeft, secondsLeft);
        return timerFormat;
    }
}
