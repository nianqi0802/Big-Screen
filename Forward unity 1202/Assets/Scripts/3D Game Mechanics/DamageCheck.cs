using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCheck : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Debug.Log("Damaged");
        }
    }
}