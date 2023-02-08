using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;

    private float h;
    private float v;

    private bool facingRight;

    [SerializeField] private float moveSpeed;

    private bool doorOpen;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        doorOpen = false;
        facingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(h * moveSpeed, v * moveSpeed);

        if (facingRight && h < 0)
        {
            Flip();
        }
        else if (!facingRight && h > 0)
        {
            Flip();
        }
    }

    private void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
        facingRight = !facingRight;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Door"))
        {
            if (!doorOpen)
            {
                doorOpen = true;
                //Destroy(collision.collider.gameObject);
                GameObject door = collision.collider.gameObject;
                door.transform.localScale = new Vector3(0.5f, 2, 1);
                door.transform.localPosition = new Vector3(door.transform.position.x - 1, door.transform.position.y + 1, door.transform.position.z);
            }
            
        }
    }


}
