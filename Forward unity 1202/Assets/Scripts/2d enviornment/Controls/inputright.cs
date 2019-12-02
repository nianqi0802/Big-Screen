using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputright : MonoBehaviour
{
    // Start is called before the first frame update


    private RemoteControl remoteControl;
    public GameObject otherGameObject;


    private Renderer _t;
    public Color colorBe;
    public GameObject _rc;

    public bool rightispressed;



    void Start()
    {
      _t = GetComponent<Renderer>();
        remoteControl = otherGameObject.GetComponent<RemoteControl>();

    }

    // Update is called once per frame
    void Update()
    {

        rightispressed = remoteControl.rightispressed;



        if (_t.material.color == colorBe && rightispressed) {
        _rc.SetActive(true);
      }
        if (!rightispressed) {
        _rc.SetActive(false);
      }
    }
}
