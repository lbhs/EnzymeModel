using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManagerScript : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip successClip;
    public AudioClip failureClip;
  
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        EventManager.bondBreakSuccess += PlaySuccessSound;
        EventManager.bondBreakFailure += PlayFailureSound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlaySuccessSound()
    {
        audioSource.clip = successClip;
        audioSource.Play();
    }

    private void PlayFailureSound()
    {
        audioSource.clip = failureClip;
        audioSource.Play();
    }

    private void OnDestroy()
    {
        EventManager.bondBreakSuccess -= PlaySuccessSound;
        EventManager.bondBreakFailure -= PlayFailureSound;
    }
}
