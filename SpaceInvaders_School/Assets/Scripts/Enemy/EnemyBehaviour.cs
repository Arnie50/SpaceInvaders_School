using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public AudioClip clip;

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Laser")
        {
            
            print("I'm Hit");
           
            AudioSource.PlayClipAtPoint(clip, Vector2.zero);
            
            Destroy(gameObject);
            
            Destroy(collision.gameObject);
            
        }
    }
}
