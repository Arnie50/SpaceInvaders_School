using System.Collections;
using UnityEngine;

public class Rocko : MonoBehaviour
{
    public float minPosX;
    public float maxPosX;
    public float moveDistance;
    public float timeStep;

    private bool isMovingRight = true;

    
    void Start()
    {
        
        InvokeRepeating("MoveEnemies", timeStep, timeStep);
    }

    void MoveEnemies()
    {
        if (isMovingRight)
        {
            float newPositionX = transform.position.x + moveDistance;
            transform.position = new Vector2(newPositionX, transform.position.y);
           
            if (newPositionX >= maxPosX)
            {
                isMovingRight = false;
            }
        }
        else
        {
            float newPositionX = transform.position.x - moveDistance;
            transform.position = new Vector2(newPositionX, transform.position.y);
           
            if (newPositionX <= minPosX)
            {
                isMovingRight = true;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Laser")
        {
            print("No way through");
                              
            Destroy(collision.gameObject);
        }
    }
}