using System.Collections;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] public AudioSource source;
    [SerializeField] public AudioClip[] musicOrder;
    [SerializeField] private int musicCounter = 0;
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
            playNextMusic = false;
            CrossFadeAudios();
        }

    }

    public void CrossFadeAudios()
    {
        StartCoroutine(FadeOut(source, fadeDuration));
    }

    public void PlayNextClip()
    {
        source.clip = musicOrder[musicCounter];
        musicCounter++;
        source.Play();
    }

    // From https://discussions.unity.com/t/fade-out-audio-source/585912/6
    private IEnumerator FadeOut(AudioSource audioSource, float duration)
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

    private IEnumerator FadeIn(AudioSource audioSource, float duration)
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
