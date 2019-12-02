using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oricolor : MonoBehaviour
{
    // Start is called before the first frame update
    private Renderer _t;
    public Color colorTurn;
    public Color colorBe;

    void Start()
    {
      _t = GetComponent<Renderer>();
      _t.material.color = colorTurn;
    }

    void OnTriggerEnter(Collider other)
    {
      if (other.gameObject.CompareTag ("music")){
        _t.material.color = colorBe;
      }
    }

    void OnTriggerExit(Collider other)
    {
      if (other.gameObject.CompareTag ("music")){
        _t.material.color = colorTurn;
      }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
