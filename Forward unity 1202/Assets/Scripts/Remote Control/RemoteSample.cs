using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RemoteSample : MonoBehaviour
{
    public GameObject LTrigger;
    public GameObject RTrigger;

    private float xNewValue = 1;
    private float xOrigional = 1;

    public float yNewValue;
    public float yOrigional;

    private float zNewValue = 1;
    private float zOrigional = 1;


    // set the remoteControl script as a variable
    private RemoteControl remoteControl;
    public GameObject otherGameObject;


    // set the default value of different state
    public bool switchscene = false;
    public bool leftispressed;
    public bool rightispressed;
    public bool botharepressed;


    private void Start()
    {

        // get the script from other object
        // set 'remotecontrol' as the other object in unity
        remoteControl = otherGameObject.GetComponent<RemoteControl>();
    }

    // Update is called once per frame
    private void Update()
    {
        //get the new value of different states
        leftispressed = remoteControl.leftispressed;
        rightispressed = remoteControl.rightispressed;
        botharepressed = remoteControl.bothispressed;

        switchscene = remoteControl.switchscene;


        LTriggerControl();
        RTriggerControl();

        SwitchScene();




    }

    private void LTriggerControl()
    //Trigger set to "YLowValue" when L arrow is down; Set to "YOrigional" when released
    {
       //left is pressed stage
       if (leftispressed || botharepressed || Input.GetKeyDown("left"))
        {
            LTrigger.transform.localScale = new Vector3(xNewValue, yNewValue, zNewValue);
        }

       //left is not pressed stage
        else if (!leftispressed && !botharepressed)
        {
            LTrigger.transform.localScale = new Vector3(xOrigional, yOrigional, zOrigional);
        }

        else if (Input.GetKeyUp("left"))
        {
            LTrigger.transform.localScale = new Vector3(xOrigional, yOrigional, zOrigional);
        }
    }

    private void RTriggerControl()
    //Trigger set to "YLowValue" when R arrow is down; Set to "YOrigional" when released
    {
        // right is pressed stage
        if (rightispressed || botharepressed || Input.GetKeyDown("right"))
        {
            RTrigger.transform.localScale = new Vector3(xNewValue, yNewValue, zNewValue);
        }

        // right is not pressed stage
        else if (Input.GetKeyUp("right"))
        {
            RTrigger.transform.localScale = new Vector3(xOrigional, yOrigional, zOrigional);
        }

        else if (!rightispressed && !botharepressed)
        {
            RTrigger.transform.localScale = new Vector3(xOrigional, yOrigional, zOrigional);
        }
    }


    //switch scene function 
    private void SwitchScene()
    {

        if (switchscene)
        {

            SceneManager.LoadScene("Ocean");
        }
    }
}