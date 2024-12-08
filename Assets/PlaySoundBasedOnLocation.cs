using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PersistentManager;

// Playing audio based on the current location
public class PlaySoundBasedOnLocation : MonoBehaviour
{
    public List<AudioClip> soundclips;
    public bool playIntroSound;

    public float lengthOfCurrentClip;

    private AudioSource _audiosource;
    private AudioClip eruptionStateClip;

    private void OnEnable()
    {
        _audiosource = GetComponent<AudioSource>();

        if (playIntroSound)
        {
            PlayClipInstantly(soundclips[0]);
        }
        else
        {
            if (PersistentManager.Instance.SceneID == 1)
            {
                eruptionStateClip = soundclips[1];
                Debug.Log("eruptionStateClip length in seconds is: " + eruptionStateClip.length);

                PlayClipInstantly(eruptionStateClip);

                switch (PersistentManager.Instance.NextLocation)
                {
                    case WorldLocation.Smith:
                        StartCoroutine(PlayClipAfterDelay(eruptionStateClip.length, soundclips[3])); // smithy
                        break;
                    case WorldLocation.Alley:
                        StartCoroutine(PlayClipAfterDelay(eruptionStateClip.length, soundclips[2])); // alley
                        break;
                    default:
                        Debug.LogError("No narration sound played!");
                        break;
                }
            }

            if (PersistentManager.Instance.SceneID == 2)
            {
                eruptionStateClip = soundclips[4];
                Debug.Log("eruptionStateClip length in seconds is: " + eruptionStateClip.length);

                PlayClipInstantly(eruptionStateClip);

                switch (PersistentManager.Instance.NextLocation)
                {
                    case WorldLocation.Harbour:
                        StartCoroutine(PlayClipAfterDelay(eruptionStateClip.length, soundclips[5])); // harbour
                        break;
                    case WorldLocation.Outskirts:
                        StartCoroutine(PlayClipAfterDelay(eruptionStateClip.length, soundclips[6])); // outskirts
                        break;
                    case WorldLocation.Villa:
                        StartCoroutine(PlayClipAfterDelay(eruptionStateClip.length, soundclips[7])); // villa
                        break;
                    default:
                        Debug.LogError("No narration sound played!");
                        break;
                }
            }

            if (PersistentManager.Instance.SceneID == 3)
            {
                eruptionStateClip = soundclips[8];
                Debug.Log("eruptionStateClip length in seconds is: " + eruptionStateClip.length);

                PlayClipInstantly(eruptionStateClip);

                switch (PersistentManager.Instance.NextLocation)
                {
                    case WorldLocation.Market:
                        StartCoroutine(PlayClipAfterDelay(eruptionStateClip.length, soundclips[9])); // market
                        break;
                    case WorldLocation.Smith:
                        StartCoroutine(PlayClipAfterDelay(eruptionStateClip.length, soundclips[10])); // smithy
                        break;
                    case WorldLocation.Alley:
                        StartCoroutine(PlayClipAfterDelay(eruptionStateClip.length, soundclips[11])); // street
                        break;
                    default:
                        Debug.LogError("No narration sound played!");
                        break;
                }
            }

            if (PersistentManager.Instance.SceneID == 4)
            {
                switch (PersistentManager.Instance.NextLocation)
                {
                    case WorldLocation.Harbour:
                        PlayClipInstantly(soundclips[12]);
                        break;
                    case WorldLocation.Outskirts:
                        PlayClipInstantly(soundclips[13]);
                        break;
                    case WorldLocation.Villa:
                        PlayClipInstantly(soundclips[14]);
                        break;
                    default:
                        Debug.LogError("No narration sound played!");
                        break;
                }
            }
        }
    }

    private void PlayClipInstantly(AudioClip clipToPlay)
    {
        Debug.Log("Eruption state has started playing");
        _audiosource.clip = clipToPlay;
        _audiosource.Play();
    }

    private IEnumerator PlayClipAfterDelay(float delay, AudioClip clipToPlay)
    {
        Debug.Log("Starting delay before playing location sound...");
        yield return new WaitForSeconds(delay);
        _audiosource.clip = clipToPlay;
        _audiosource.Play();
        Debug.Log("Location sound has started playing");
    }
}
