using System.Collections.Generic;
using UnityEngine;

public class GameplaySequenceHub : MonoBehaviour {
    public static GameplaySequenceHub instance;

    public Dictionary<int, string[]> dayScene = new Dictionary<int, string[]> {
        {1, new string[] {}},
        {2, new string[] {}},
        {3, new string[] {}},
        {4, new string[] {}},
        {5, new string[] {}},
        {6, new string[] {}},
        {7, new string[] {}}
    };

    private void Awake() { // making things singleton
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != this) {
            Destroy(this);
        }
    }
}
