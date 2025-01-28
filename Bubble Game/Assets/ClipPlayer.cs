using UnityEngine;

public class ClipPlayer : MonoBehaviour
{
    [SerializeField] AudioSource source;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(source.isPlaying == false)
        {
            Destroy(this);
        }
    }
}
