using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyMove : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 1f;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}