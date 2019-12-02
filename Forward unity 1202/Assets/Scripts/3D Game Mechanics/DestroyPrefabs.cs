using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPrefabs : MonoBehaviour
{
    public bool hit = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            hit = true;
            Debug.Log(hit);
        }
    }
}