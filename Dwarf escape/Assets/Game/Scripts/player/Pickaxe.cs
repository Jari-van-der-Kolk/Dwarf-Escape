using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class Pickaxe : MonoBehaviour
    {
        private DefaultInputActions defaultInputActions;
        
        private float dir;
        [SerializeField] private float mineDistance;
        [SerializeField] private LayerMask mask;
        public int hitAmount;

        private void Awake()
        {
            defaultInputActions = new DefaultInputActions();
            defaultInputActions.Player.Mine.Enable();
            defaultInputActions.Player.Mine.performed += Mine;
        }

        private void LateUpdate()
        {
            Debug.DrawRay(transform.position, transform.right, Color.magenta);

        }
        private void Mine(InputAction.CallbackContext context)
        {
            Debug.Log("fuck you");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, mineDistance, mask);
            if (hit.collider != null)
                hit.collider.GetComponent<IHitable>().Hit(hitAmount);
        }
        
        
        /*private void RotateToAngle()
        {
            float angleAmount = 360 / this.angleAmount; 
            dir = _faceMousePos.angle / angleAmount;
            dir = Mathf.RoundToInt(dir);
            dir *= angleAmount;
            transform.rotation = Quaternion.AngleAxis(dir, Vector3.forward);
            Debug.DrawRay(transform.position, transform.right * mineDistance, Color.red);

        }*/
    }
}