using UnityEngine;

public class ScoringSystem : MonoBehaviour {
    public static ScoringSystem instance;
    public int globalScore = 0;
    public int dailyScore = 0;
    public int goalScore = 50;

    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != this) {
            Destroy(this);
        }
    }
}
