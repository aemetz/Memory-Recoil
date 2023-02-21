using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float timeLive = 3.0f;
    [SerializeField] public float BulletDamage = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = bulletSpeed * transform.right;
    }
    void Update()
    {
        Destroy(gameObject, timeLive);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().LoseHealth(BulletDamage);
        }
        if (collision.CompareTag("WaveTrigger") == false)
        {
            //Debug.Log(collision.collider.gameObject.name);
            //Debug.Log(collision.collider.gameObject.tag);
            Destroy(gameObject);
        }
        
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.name != "WaveTrigger")
        {
            //Debug.Log(collision.collider.gameObject.name);
            //Debug.Log(collision.collider.gameObject.tag);
            Destroy(gameObject);
        }
    }
}
