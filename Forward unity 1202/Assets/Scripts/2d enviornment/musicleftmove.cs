using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicleftmove : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform _center;
    [SerializeField]
    private Transform _origin;
    public float speed;
    private Vector3 _c,_o;
    void Start()
    {
      _c = new Vector3(_center.position.x, transform.position.y, transform.position.z);
      _o = new Vector3(_origin.position.x, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
      if (transform.position.x < _c.x) {
        transform.position = Vector3.MoveTowards(transform.position, _c, speed * Time.deltaTime);
      }
      else {
        transform.position = _o;
      }
    }
}
