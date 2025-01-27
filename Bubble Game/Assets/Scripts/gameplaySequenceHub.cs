using System.Collections.Generic;
using UnityEngine;

public class GameplaySequenceHub : MonoBehaviour {
    public static GameplaySequenceHub instance;

    public Dictionary<int, string[]> dayScene = new Dictionary<int, string[]> {
        {1, new string[] {
            "Finally, a new untapped market... I've made it!",
            "The big city was too competitive, every human already knows the delicacy that is...",
            "BUBBLE TEA!",
            "But here in Magskjoldr, there's a ton of creatures who've never tasted the drink of the gods!",
            "Finally, I can make the gold I always deserved and rule a boba empire! Mwahah--",
            "Good thing I have my handy <color=#0088AA>Guidebook</color> if I get stuck making an order. Maybe I should look at it now...",
            "Oh look!, my first customer!"}
        },
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
