using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketTrigger : MonoBehaviour
{
    public int itemCount = 0;
    void OnTriggerEnter(Collider other)
    {
        if (other != null && other.CompareTag("Respawn"))
        {
            itemCount++;
            Debug.Log("Предметов собрано: " + itemCount);
            Destroy(other.gameObject);
        }
    }
}
