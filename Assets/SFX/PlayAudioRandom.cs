using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioRandom : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioClip[] audioClips; // Array of audio clips to choose from
    public AudioSource audioSource; // The AudioSource component to play the sounds

    [Header("Randomization Settings")]
    public Vector2 pitchRange = new Vector2(0.8f, 1.2f); // Min and max pitch
    public Vector2 volumeRange = new Vector2(0.5f, 1.0f); // Min and max volume

    [Header("Playback Settings")]
    public Vector2 intervalRange = new Vector2(5f, 15f); // Min and max time between sounds

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (audioClips.Length > 0)
        {
            StartCoroutine(PlayRandomAudio());
        }
        else
        {
            Debug.LogWarning("No audio clips assigned to the RandomAudioPlayer script.");
        }
    }

    private IEnumerator PlayRandomAudio()
    {
        while (true)
        {
            float waitTime = Random.Range(intervalRange.x, intervalRange.y); // Random interval
            yield return new WaitForSeconds(waitTime);

            PlayRandomClip(); // Play a random clip
        }
    }

    private void PlayRandomClip()
    {
        if (audioClips.Length == 0) return;

        AudioClip selectedClip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.pitch = Random.Range(pitchRange.x, pitchRange.y);
        audioSource.volume = Random.Range(volumeRange.x, volumeRange.y);
        audioSource.PlayOneShot(selectedClip);
    }
}