using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBeatMove : MonoBehaviour
{
    private Rigidbody rb;
    public float Speed;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        MoveRight();
    }

    private void MoveRight()
    {
        rb.MovePosition(transform.position + transform.right * Time.deltaTime * Speed);
    }
}