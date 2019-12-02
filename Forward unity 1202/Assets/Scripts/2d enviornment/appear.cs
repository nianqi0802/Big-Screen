using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appear : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform _left;
    [SerializeField]
    private Transform _right;
    private float speed = 2;
    private Vector3 pl,pr;

    void Start()
    {
      pl = new Vector3 (_left.position.x, transform.position.y, transform.position.z);
      pr = new Vector3 (_right.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
      if (transform.position.x > pl.x) {
        transform.position = Vector3.MoveTowards(transform.position, pl, speed*Time.deltaTime);
      }
      else {
        transform.position = pr;
      }

    }

}
