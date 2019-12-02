using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Test1 : MonoBehaviour
{
    //private float startTime;
    //public float startTime;

    public GameObject LNotes;
    private GameObject _LNote;
    public GameObject LOrigin;

    private bool LSpwanCheck = false;

    public GameObject RNotes;
    private GameObject _RNote;
    public GameObject ROrigin;

    private bool RSpwanCheck = false;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnLNotes), 0f, 2.0f);
        InvokeRepeating(nameof(SpawnRNotes), 0f, 2.0f);
    }

    private void Update()
    {
    }

    private void SpawnLNotes()
    {
        _LNote = Instantiate(LNotes, LOrigin.transform.position, Quaternion.identity);
    }

    private void SpawnRNotes()
    {
        _RNote = Instantiate(RNotes, ROrigin.transform.position, Quaternion.identity);
    }
}