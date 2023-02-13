using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;



    public Camera GameCamera;


    [SerializeField] private float moveSpeed;

    private bool doorOpen;
    Vector2 InputMovement;
    Vector2 AimDirection;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        doorOpen = false;
        



    }

    // Update is called once per frame
    void Update()
    {
        
        InputMovement.x = Input.GetAxisRaw("Horizontal");
        InputMovement.y = Input.GetAxisRaw("Vertical");
        AimDirection = GameCamera.ScreenToWorldPoint(Input.mousePosition);

    }

    
    void FixedUpdate()
    {
        
        rb.MovePosition(rb.position + InputMovement * moveSpeed * Time.fixedDeltaTime);


        Vector2 LookingAt = AimDirection - rb.position;
        float turnAngle = Mathf.Atan2(LookingAt.y, LookingAt.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = turnAngle;
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
