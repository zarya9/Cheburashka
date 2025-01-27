using UnityEngine;

public class OrangeBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered with: " + other.name);
            if (other.CompareTag("Basket"))
        {
            // ”ничтожаем апельсин
            Destroy(gameObject);
        }
    }
}