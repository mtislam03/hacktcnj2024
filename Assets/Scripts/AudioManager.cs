using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance = null;

    private void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    private int numSources = 5;
    private int currIdx = 0;

    public void PlayEffect(AudioClip clip)
    {
        AudioSource currSource = transform.GetChild(currIdx).GetComponent<AudioSource>();
        currIdx = (currIdx + 1) % numSources;
        currSource.clip = clip;
        currSource.Play();
    }
}
