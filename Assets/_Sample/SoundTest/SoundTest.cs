using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sample
{
    public class SoundTest : MonoBehaviour
    {
        #region Variables
        private AudioSource audioSource;

        private AudioClip clip;         // 재생할 오디오 클립

        [SerializeField] private float volume = 1.0f;
        [SerializeField] private float pitch = 1.0f;
        [SerializeField] private bool loop = false;
        [SerializeField] private bool playOnAwake = false;
        #endregion

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            SoundPlay();
        }

        void SoundPlay()
        {
            audioSource.clip = clip;
            audioSource.volume = volume;
            audioSource.pitch = pitch;
            audioSource.loop = loop;

            audioSource.Play();
        }

        void SoundOnShot()
        {
            audioSource.PlayOneShot(clip);
        }
    }
}

