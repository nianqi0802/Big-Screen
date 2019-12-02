using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteControl : MonoBehaviour
{

    private Connection _connection;

    public bool leftispressed = false;
    public bool rightispressed = false;
    public bool bothispressed = false;
    public bool switchscene = false;

    void Awake()
    {
        _connection = new Connection("https://www.bigscreens.live/socket.io/", "BeatMatchingProject", "game");

        _connection.OnConnect(() =>
        {
            Debug.Log("CONNECTED");
        });

        _connection.OnDisconnect(() =>
        {
            Debug.Log("DISCONNECTED");
        });

        _connection.OnOtherConnect((id, type) =>
        {
            Debug.Log($"OTHER CONNECTED: {id} {type}");
        });

        _connection.OnOtherDisconnect((id, type) =>
        {
            Debug.Log($"OTHER DISCONNECTED: {id} {type}");
        });

        _connection.OnError((err) =>
        {
            Debug.LogError(err);
        });

        _connection.On("create-left", (id) =>
        {
            Debug.Log("left key!");
            leftispressed = true;



        });

        _connection.On("down-left", (id) =>
        {
            Debug.Log("left key out!");
            leftispressed = false;



        });


        _connection.On("create-right", (id) =>
        {
            Debug.Log("right key!");
            rightispressed = true;


        });

        _connection.On("down-right", (id) =>
        {
            Debug.Log("right key out!");
            rightispressed = false;


        });

        _connection.On("create-both", (id) =>
        {
            Debug.Log("both key!");
            bothispressed = true;


        });

        _connection.On("down-both", (id) =>
        {
            Debug.Log("both key out!");
            bothispressed = false;


        });


        _connection.On("switch-scene", (id) =>
        {
            Debug.Log("switch scene!");
            switchscene = true;


        });


        _connection.Open();
    }




}
