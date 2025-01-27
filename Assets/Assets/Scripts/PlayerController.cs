using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    public float minX = -5f;
    public float maxX = -4f;
    public float minY = -3f;
    public float maxY = 2f;
    private bool canMove = true;

    void Update()
    {
        if (canMove)
        {
            if (Input.GetKey(KeyCode.Q))
            {
                Move(Vector2.left + Vector2.up);
                FlipCharacter(true);
            }
            if (Input.GetKey(KeyCode.A))
            {
                Move(Vector2.left - Vector2.up);
                FlipCharacter(true);
            }
            if (Input.GetKey(KeyCode.E))
            {
                Move(Vector2.right + Vector2.up);
                FlipCharacter(false);
            }
            if (Input.GetKey(KeyCode.D))
            {
                Move(Vector2.right - Vector2.up);
                FlipCharacter(false);
            }
        }
        ClampPosition();
    }

    private void Move(Vector2 direction)
    {
        direction.Normalize();

        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void ClampPosition()
    {
        Vector3 clampedPosition = transform.position;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);

        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minY, maxY);

        transform.position = clampedPosition;
    }
    private void FlipCharacter(bool faceRight)
    {
        // Поворачиваем персонажа на основе направления движения
        Vector2 localScale = transform.localScale;
        if (faceRight && localScale.x < 0)  // Если персонаж смотрит влево, поворачиваем вправо
        {
            localScale.x = -localScale.x;
        }
        else if (!faceRight && localScale.x > 0)  // Если персонаж смотрит вправо, поворачиваем влево
        {
            localScale.x = -localScale.x;
        }
        transform.localScale = localScale;
    }
    public void StopMovement()
    {
        canMove = false;
    }
    public void ResumeMovement()
    {
        canMove = true;
    }
}
