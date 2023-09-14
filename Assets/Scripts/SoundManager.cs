using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Author: Zheyuan Gao
namespace GaoZheyuan.Lab6
{
    /* 
     * Sound Manager will play different backgroun sounds and sound effects 
     * based on the current game state.
    */
    public class SoundManager : MonoBehaviour
    {

        [SerializeField] private AudioClip backgroundMusic;
        [SerializeField] private AudioClip deathSound;
        private AudioSource audioSource;
        private Boolean soundPlaying = false;

        // Start is called before the first frame update
        void Start()
        {
            // The background music will loop after game starts
            audioSource = GetComponent<AudioSource>();
            audioSource.clip = backgroundMusic;
            audioSource.loop = true;
            audioSource.Play();
        }

        // Update is called once per frame
        void Update()
        {
     
        }

        public void PlayDeathSound()
        {
            if (!soundPlaying)
            {
                soundPlaying = true;
                // Play the death sound effect
                audioSource.Stop();
                audioSource.clip = deathSound;
                audioSource.loop = false;
                audioSource.Play();
            }

        }
    }
}