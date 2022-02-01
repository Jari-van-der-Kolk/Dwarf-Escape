using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class FaceMousePos : MonoBehaviour
    {
        private Camera _camera;
        public float angle;
        private void Awake()
        {
            _camera = Camera.main;
        }
        void Update()
        {
            Vector2 mousePos = Input.mousePosition- _camera.WorldToScreenPoint(transform.position);
            angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
