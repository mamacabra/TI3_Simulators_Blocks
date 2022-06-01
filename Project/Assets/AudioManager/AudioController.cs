using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    AudioSource audioSource;
    float minimumPitch = 0.5f;
    float maximumPitch = 2f;
    float speed = 1f;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = minimumPitch;
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.pitch = speed;
        float v = Input.GetAxis("Vertical");
       
    }
}
