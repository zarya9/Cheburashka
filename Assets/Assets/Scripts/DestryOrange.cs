using System.Collections;
using UnityEngine;

public class DestryOrange : MonoBehaviour
{
    public float orangeSpeed = 5f;
    private Score scoreManager;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreManager = FindObjectOfType<Score>();
        StartCoroutine(DestroyAfterDelay());
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Basket"))
        {
            if (scoreManager != null)
            {
                scoreManager.AddScore(1);
            }
            Destroy(gameObject);
        }
        else if (other.CompareTag("Floor"))
        {
            PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage();
            }

            Destroy(gameObject);
        }
    }

    public void SetSpeed(float newSpeed)
    {
        orangeSpeed = newSpeed;
    }
}