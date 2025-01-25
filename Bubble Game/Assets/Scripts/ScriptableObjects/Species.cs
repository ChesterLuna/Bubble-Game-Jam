using UnityEngine;

[CreateAssetMenu(fileName = "Species", menuName = "Scriptable Objects/Species")]
public class Species : ScriptableObject
{
    [SerializeField] string speciesName;
    [SerializeField] Sprite mainBody;
    [SerializeField] Sprite[] faceFeatures;
    
}
