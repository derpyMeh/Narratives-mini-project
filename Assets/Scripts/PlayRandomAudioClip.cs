using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomAudioClip : MonoBehaviour
{
    public List<AudioClip> Clips;
    public List<AudioClip> PickableClips;
    private int ranMin = 5, ranMax = 12;

    private AudioSource _source;
    void Start()
    {
        _source = GetComponent<AudioSource>();

        if (Clips.Count > 0)
            StartCoroutine(playSoundAfterRandomTime());
        else
            Debug.LogWarning("No audioclips in the list!");

        PickableClips = new List<AudioClip>(Clips);
    }

    private IEnumerator playSoundAfterRandomTime()
    {
        yield return new WaitForSeconds(Random.Range(ranMin, ranMax));

        int ranNum = Random.Range(0, PickableClips.Count);
        
        _source.clip = PickableClips[ranNum];
        _source.Play();

        PickableClips.RemoveAt(ranNum);

        if (PickableClips.Count == 0) //If no more audio clips back in the pickable list.
            PickableClips = new List<AudioClip>(Clips);

        StartCoroutine(playSoundAfterRandomTime());
    }
}
