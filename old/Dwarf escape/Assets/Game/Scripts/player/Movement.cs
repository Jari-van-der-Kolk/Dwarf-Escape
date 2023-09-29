using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{

    public class Movement : MonoBehaviour
    {
        public static Movement instance;
        
        [SerializeField] private float moveSpeed;
        [HideInInspector] public Transform playerTransform;

        

        private Rigidbody2D rb;
        private InputActions playerController;
        
        private void Awake()
        {
            instance = this;
            
            rb = GetComponent<Rigidbody2D>();

            playerController = new InputActions();
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

        public void SetPosition(Vector2 pos) => transform.position = pos;


    }
}
