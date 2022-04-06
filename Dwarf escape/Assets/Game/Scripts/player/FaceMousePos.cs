using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class FaceMousePos : MonoBehaviour
    {
        private Camera _camera;
        private float angle;
         
        private void Awake()
        {
            _camera = Camera.main;
        }
        void Update()
        {
            Vector2 mousePos = Mouse.current.position.ReadValue() - (Vector2)_camera.WorldToScreenPoint(transform.position);
            angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); 
        }
    }
}
