using UnityEngine;

[CreateAssetMenu(fileName = "Species", menuName = "Scriptable Objects/Species")]
public class Species : ScriptableObject
{
    public string speciesName;
    public Sprite mainBody;
    public Sprite[] faceFeatures;
    
}
