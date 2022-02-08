using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{

    public class Movement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;
        [HideInInspector] public Transform playerTransform;

        private Rigidbody2D rb;
        private DefaultInputActions playerController;
        
        private void Awake()
        { 
            rb = GetComponent<Rigidbody2D>();

            playerController = new DefaultInputActions();
            playerController.Player.Move.Enable();
        }

        private void Update()
        {
           Move();
        }

        private void Move()
        {
            Vector2 movement = playerController.Player.Move.ReadValue<Vector2>() * (Time.deltaTime * moveSpeed);;
            rb.MovePosition(rb.position += movement);
        }
    }
}
