using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Boy;
    private Vector3 offset;

    void Start()
    {
      offset = transform.position - Boy.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }


    void LateUpdate()
    {
      transform.position = Boy.transform.position + offset;
    }
}
