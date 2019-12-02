using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputleft : MonoBehaviour
{
    // Start is called before the first frame update
   
    private RemoteControl remoteControl;
    public GameObject otherGameObject;


    private Renderer _t;
    public Color colorBe;
    public GameObject _lc;


    public bool leftispressed;

    void Start()
    {
      _t = GetComponent<Renderer>();
        remoteControl = otherGameObject.GetComponent<RemoteControl>();

    }

    // Update is called once per frame
    void Update()
    {

        leftispressed = remoteControl.leftispressed;

      if (_t.material.color == colorBe && leftispressed) {
        _lc.SetActive(true);
      }
        if (!leftispressed) {
        _lc.SetActive(false);
      }
    }
}
