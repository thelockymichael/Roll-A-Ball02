using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayExplosionSound : MonoBehaviour
{

    public  AudioClip[] explosion;

    private AudioSource audioSource;

    private AudioClip explosionClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // explosion1 = GetComponent<AudioSource>();
        //PlaySound(3);
        PlaySound();
        Debug.Log("started");
    }

    public void PlaySound()
    {
        int index = Random.Range(0, explosion.Length);
        explosionClip = explosion[index];
        audioSource.clip = explosionClip;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
