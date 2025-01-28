using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] public float timeLeft = 60f;
    public bool countingDown = false;


    // Update is called once per frame
    void Update()
    {
        if (countingDown)
        {
            timeLeft -= Time.deltaTime;
        }

        if(timeLeft <= 0f)
        {
            TimerFinished();
        }
    }

    void TimerFinished()
    {
        // Switch day
    }

    public void StartTimer()
    {
        countingDown = true;
    }
}
