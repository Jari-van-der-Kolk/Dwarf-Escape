using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        transform.position += Vector3.up * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow))
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
