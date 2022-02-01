using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{

    public class Movement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [HideInInspector] public Transform playerTransform;

        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            playerTransform = transform;
        }

        void Update()
        {
            Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * Time.deltaTime * moveSpeed;
            rb.MovePosition(rb.position += movement);
        }
    }
}
