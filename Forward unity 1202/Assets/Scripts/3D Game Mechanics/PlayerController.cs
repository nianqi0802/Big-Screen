using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject LTrigger;
    public GameObject RTrigger;

    private float xNewValue = 1;
    private float xOrigional = 1;

    public float yNewValue;
    public float yOrigional;

    private float zNewValue = 1;
    private float zOrigional = 1;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        LTriggerControl();
        RTriggerControl();
    }

    private void LTriggerControl()
    //Trigger set to "YLowValue" when L arrow is down; Set to "YOrigional" when released
    {
        if (Input.GetKeyDown("left"))
        {
            LTrigger.transform.localScale = new Vector3(xNewValue, yNewValue, zNewValue);
        }
        else if (Input.GetKeyUp("left"))
        {
            LTrigger.transform.localScale = new Vector3(xOrigional, yOrigional, zOrigional);
        }
    }

    private void RTriggerControl()
    //Trigger set to "YLowValue" when R arrow is down; Set to "YOrigional" when released
    {
        if (Input.GetKeyDown("right"))
        {
            RTrigger.transform.localScale = new Vector3(xNewValue, yNewValue, zNewValue);
        }
        else if (Input.GetKeyUp("right"))
        {
            RTrigger.transform.localScale = new Vector3(xOrigional, yOrigional, zOrigional);
        }
    }
}