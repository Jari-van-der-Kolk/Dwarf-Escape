using System;
using UnityEngine;

namespace Player
{
    public class Pickaxe : MonoBehaviour
    {
        private float dir;
        [SerializeField] private float mineDistance;
        [SerializeField] private LayerMask mask;
        public int hitAmount;
        
        private void LateUpdate()
        {
            Debug.DrawRay(transform.position, transform.right, Color.magenta);

            if(Input.GetMouseButtonDown(0))
                Mine();
        }
        private void Mine()
        {
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