using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RBeatMove : MonoBehaviour
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
        MoveLeft();
    }

    private void MoveLeft()
    {
        rb.MovePosition(transform.position - transform.right * Time.deltaTime * Speed);
    }
}