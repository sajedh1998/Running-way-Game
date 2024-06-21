using UnityEngine;

namespace Sound
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance { get; private set; }

        [SerializeField] private AudioClip[] effects;
        private AudioSource audioSource;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            audioSource = GetComponent<AudioSource>();
        }

        public void PlaySound(int soundIndex)
        {
            if (soundIndex < 0 || soundIndex >= effects.Length)
            {
                Debug.LogError("Invalid sound index!");
                return;
            }

            audioSource.PlayOneShot(effects[soundIndex]);
        }
    }
}
