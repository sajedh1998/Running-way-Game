using UnityEngine;

namespace Sound
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance;
        public AudioClip[] effects;
        private AudioSource audioSource;

        private void Start()
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
        }

        public void PlaySound(int soundIndex)
        {          
            audioSource.PlayOneShot(effects[soundIndex]);
        }
    }
}