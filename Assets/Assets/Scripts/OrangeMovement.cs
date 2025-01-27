using UnityEngine;

public class OrangeMovement : MonoBehaviour
{
    private float speed = 2f;
    private float targetSpeed;

    void Start()
    {
        targetSpeed = speed;
    }

    void Update()
    {
        speed = Mathf.Lerp(speed, targetSpeed, Time.deltaTime * 2f); 
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    public void SetSpeed(float newSpeed)
    {
        targetSpeed = newSpeed;
    }
}
