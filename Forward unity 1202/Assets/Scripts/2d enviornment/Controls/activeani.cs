using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class activeani : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _leftani;
    public GameObject _rightani;

    private RemoteControl remoteControl;
    public GameObject otherGameObject;
    public bool switchscene = false;
    public bool leftispressed;
    public bool rightispressed;
    public bool botharepressed;

    void Start()
    {
        remoteControl = otherGameObject.GetComponent<RemoteControl>();
    }

    // Update is called once per frame
    void Update()
    {
        leftispressed = remoteControl.leftispressed;
        rightispressed = remoteControl.rightispressed;
        botharepressed = remoteControl.bothispressed;

        LTriggerControl();
        RTriggerControl();
        switchscene = remoteControl.switchscene;
        if (switchscene || Input.GetKeyDown("space")) {
            //if (Input.GetKeyDown("space")) {
            SceneManager.LoadScene("Ocean");
        }
    }

    private void LTriggerControl()
    //Trigger set to "YLowValue" when L arrow is down; Set to "YOrigional" when released
    {
        if (leftispressed || botharepressed || Input.GetKeyDown("left"))
        // if (Input.GetKeyDown("left"))
        {
            _leftani.SetActive(true);
        }
        else if (!leftispressed && !botharepressed)
        {
            _leftani.SetActive(false);
        }
        else if (Input.GetKeyUp("left"))
        {
            _leftani.SetActive(false);

        }
    }

    private void RTriggerControl()
    //Trigger set to "YLowValue" when R arrow is down; Set to "YOrigional" when released
    {
        if (rightispressed || botharepressed || Input.GetKeyDown("right") )
        {
            _rightani.SetActive(true);
        }
        else if (!rightispressed && !botharepressed)
        {
            _rightani.SetActive(false);
        }

        else if (Input.GetKeyUp("right"))
        {
            _rightani.SetActive(false);
        }
    }
}
