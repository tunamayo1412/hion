using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBGM : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField]AudioClip defaultBGM, enemyBGM;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = defaultBGM;
        audioSource.volume = 0.1f;
        audioSource.Play();
    }

    public void Change() {
        audioSource.Stop();
        audioSource.clip = enemyBGM;
        audioSource.volume = 0.3f;
        audioSource.Play();
    }

    public void Stop() {
        audioSource.Stop();

    }
}
