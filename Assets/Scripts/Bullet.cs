using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float timeLive = 3.0f;

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
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.collider.gameObject);
        }

        if (!collision.collider.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
