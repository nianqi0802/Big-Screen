using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicchangecolor : MonoBehaviour
{
    // Start is called before the first frame update
    //reference to Sprite Renderer Component
    private Renderer rend;

    //color value that we can set in InspectorElement
    [SerializeField]
    public Color colorTurn;
    private Color ori;

    void Start()
    {
      rend = GetComponent<Renderer>();
      ori = rend.material.color;
    }

    void OnTriggerEnter2D(Collider2D other)
  	{
  		if (other.gameObject.CompareTag ("music")){
        rend.material.color = colorTurn;
      }
  	}

    void OnTriggerExit2D(Collider2D other)
  	{
  		if (other.gameObject.CompareTag ("music")){
        rend.material.color = ori;
      }
  	}

    // Update is called once per frame
    void Update(){
    }
}
