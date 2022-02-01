using System;
using UnityEngine;

namespace Player
{
    public class MineBlocks : MonoBehaviour
    {
        private float dir;
        [SerializeField] private float mineDistance;
        [SerializeField] private LayerMask mask;
        
        private void LateUpdate()
        {
            //RotateToAngle();
            if(Input.GetMouseButtonDown(0))
                Mine();
        }
        private void Mine()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, mineDistance, mask);
            if (hit.collider != null)
                hit.collider.GetComponent<IHitable>().Hit();
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