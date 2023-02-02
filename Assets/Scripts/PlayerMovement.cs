using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rb;

    private float h;
    private float v;

    [SerializeField] private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(h * moveSpeed, v * moveSpeed);
    }


}
