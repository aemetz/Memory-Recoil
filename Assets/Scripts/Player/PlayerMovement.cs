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

    Vector2 InputMovement;
    Vector2 AimDirection;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

}
