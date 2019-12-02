using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _NotesSpawnTest : MonoBehaviour
{
    private float startTime;
    //public float startTime;

    public GameObject LNotes;
    private GameObject _LNote;
    public GameObject LOrigin;
    public GameObject LDestination;
    public GameObject LTrack;
    private float LTrackLength;
    private Renderer LTrackRenderer;
    private Vector3 LTrackVector3;
    public float LSpeed;

    private bool LSpwanCheck = false;

    public GameObject RNotes;
    private GameObject _RNote;
    public GameObject ROrigin;
    public GameObject RDestination;
    public GameObject RTrack;
    private float RTrackLength;
    private Renderer RTrackRenderer;
    private Vector3 RTrackVector3;
    public float RSpeed;

    private bool RSpwanCheck = false;

    private void Start()
    {
    }

    private void Update()
    {
        SpawnLNotes();
        SpawnRNotes();
    }

    private void SpawnLNotes()
    {
        if (LSpwanCheck == false)
        {
            _LNote = Instantiate(LNotes, LOrigin.transform.position, Quaternion.identity);

            LSpwanCheck = true;
        }
        MoveLNote();
    }

    private void SpawnRNotes()
    {
        if (RSpwanCheck == false)
        {
            _RNote = Instantiate(RNotes, ROrigin.transform.position, Quaternion.identity);

            RSpwanCheck = true;
        }
        MoveRNote();
    }

    public void MoveLNote()
    {
        LTrackRenderer = LTrack.GetComponent<Renderer>();
        LTrackVector3 = LTrackRenderer.bounds.size;
        LTrackLength = LTrackVector3.x / 2;

        float LTrackDistanceTraveled = (Time.time - startTime) * LSpeed;
        float LFractionOfDistance = LTrackDistanceTraveled / LTrackLength;

        _LNote.transform.position = Vector3.Lerp(LOrigin.transform.position, LDestination.transform.position, LFractionOfDistance);

        //Debug.Log("LTrackVector3 : " + LTrackVector3);
        //Debug.Log(_LNote.transform.position);
    }

    public void MoveRNote()
    {
        RTrackRenderer = RTrack.GetComponent<Renderer>();
        RTrackVector3 = RTrackRenderer.bounds.size;
        RTrackLength = RTrackVector3.x / 2;

        float RTrackDistanceTraveled = (Time.time - startTime) * RSpeed;
        float RFractionOfDistance = RTrackDistanceTraveled / RTrackLength;

        _RNote.transform.position = Vector3.Lerp(ROrigin.transform.position, RDestination.transform.position, RFractionOfDistance);

        //Debug.Log("RTrackVector3 : " + RTrackVector3);
        //Debug.Log(_RNote.transform.position);
    }
}