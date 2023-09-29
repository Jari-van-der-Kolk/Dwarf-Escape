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
            //pakt de directie tussen de huidige gameobject en de muis positie op het scherm 
            Vector2 mousePos = Mouse.current.position.ReadValue() - (Vector2)_camera.WorldToScreenPoint(transform.position);
            
            
            //de pakt de grades van de vector directie
            angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            
            //draait de vector in de richting van de muis positie 
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); 
        }
    }
}
