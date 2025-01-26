using System.Collections;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] public AudioSource source;
    [SerializeField] public AudioClip[] musicOrder;
    [SerializeField] public int musicCounter = 0;
    [SerializeField] private bool playNextMusic = false;
    [SerializeField] private float fadeDuration = 0.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        musicCounter = 0;
        if (source == null) source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playNextMusic)
        {
            print("here");
            playNextMusic = false;
            StartCoroutine(FadeOut(source, fadeDuration));
        }

    }

    public void PlayNextClip()
    {
        source.clip = musicOrder[musicCounter];
        musicCounter++;
        source.Play();
    }

    // From https://discussions.unity.com/t/fade-out-audio-source/585912/6
    public IEnumerator FadeOut(AudioSource audioSource, float duration)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / duration;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
        StartCoroutine(FadeIn(audioSource, duration));
    }

    public IEnumerator FadeIn(AudioSource audioSource, float duration)
    {
        float startVolume = audioSource.volume;

        audioSource.volume = 0;
        PlayNextClip();

        while (audioSource.volume < 1.0f)
        {
            audioSource.volume += startVolume * Time.deltaTime / duration;

            yield return null;
        }

        audioSource.volume = startVolume;
    }


}
