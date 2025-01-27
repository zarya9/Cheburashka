using UnityEngine;
using UnityEngine.UI;

public class VignetteController : MonoBehaviour
{
    public Image vignetteImage;
    public PlayerHealth playerHealth;


    void Start()
    {
        if (playerHealth == null)
        {
            playerHealth = FindObjectOfType<PlayerHealth>();
        }

        if (vignetteImage != null)
        {
            vignetteImage.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Виньетка не назначена в инспекторе!");
        }
    }
    void Update()
    {
        if (playerHealth != null && vignetteImage != null)
        {
            if (playerHealth.GetCurrentHealth() == 1)
            {
                if (!vignetteImage.gameObject.activeSelf)
                {
                    vignetteImage.gameObject.SetActive(true);
                }
            }
            else
            {
                if (vignetteImage.gameObject.activeSelf)
                {
                    vignetteImage.gameObject.SetActive(false);
                }
            }
        }
    }
}
