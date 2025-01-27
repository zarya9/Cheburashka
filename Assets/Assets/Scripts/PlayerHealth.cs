    using System.Collections;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class PlayerHealth : MonoBehaviour
    {
        public GameObject[] hearts;
        public AudioClip gameOverSound;
        private int health;
        private AudioSource audioSource;
        private AudioSource gameOverAudioSource;
        private OrangeSpawner orangeSpawner;
        private PlayerController playerController;

        void Start()
        {
            health = hearts.Length;
            audioSource = GetComponent<AudioSource>();
            gameOverAudioSource = gameObject.AddComponent<AudioSource>();
            orangeSpawner = FindObjectOfType<OrangeSpawner>();
            playerController = FindObjectOfType<PlayerController>();
        }

        public void TakeDamage()
        {
            if (health > 0)
            {
                health--;
                hearts[health].SetActive(false);

            if (health == 0)
            {
                Debug.Log("Здоровье закончилось! Останавливаем фоновую музыку и воспроизводим звук...");
                AudioSource backgroundMusic = GameObject.Find("BackgroundAudio")?.GetComponent<AudioSource>();
                if (backgroundMusic != null && backgroundMusic.isPlaying)
                {
                    backgroundMusic.Stop();
                }
                else
                {
                    Debug.LogWarning("Фоновая музыка не найдена или уже остановлена!");
                }
                if (gameOverSound != null && gameOverAudioSource != null)
                {
                    gameOverAudioSource.PlayOneShot(gameOverSound);
                }
                else
                {
                    Debug.LogError("Звук или AudioSource не назначены!");
                }
                if (orangeSpawner != null)
                {
                    orangeSpawner.StopSpawning();
                }
                if (playerController != null)
                {
                    playerController.StopMovement();
                }
                StartCoroutine(RestartGameWithDelay());
            }

        }
    }

        private IEnumerator RestartGameWithDelay()
        {
            yield return new WaitForSeconds(4f);
            if (orangeSpawner != null)
            {
                orangeSpawner.ResumeSpawning();
            }
            if (playerController != null)
            {
                playerController.ResumeMovement();
            }//

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    public int GetCurrentHealth()
    {
        return health;
    }

}