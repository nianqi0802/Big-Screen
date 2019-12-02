﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowfieldParticle : MonoBehaviour
{

    public float _moveSpeed;

    public int _audioBand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * _moveSpeed * Time.deltaTime;
    }

    public void ApplyRotation(Vector3 rotation, float rotateSpeed)
    {
        Quaternion targetRoation = Quaternion.LookRotation(rotation.normalized);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRoation, rotateSpeed * Time.deltaTime);
    }
}
