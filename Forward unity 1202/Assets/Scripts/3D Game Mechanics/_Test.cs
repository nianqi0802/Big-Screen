using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Test : MonoBehaviour
{
    //private float startTime;
    //public float startTime;

    public GameObject LNotes;
    private GameObject _LNote;
    public GameObject LOrigin;

    private int LPatternCheck = 0;
    private int LPatternCheckTwo = 0;

    public GameObject RNotes;
    private GameObject _RNote;
    public GameObject ROrigin;

    private bool RSpwanCheck = false;
    private int RPatternCheck = 0;

    private bool patternOne = false;
    private bool patternTwo = false;

    private int LSequenceOne = 6;
    private int LSequenceTwo = 3;
    private int LSequenceThree = 5;

    private void Start()
    {
        StartCoroutine(Conductor());
    }

    private IEnumerator Conductor()
    {
        yield return new WaitForSeconds(2f);
        LOne();
        yield return new WaitForSeconds(2f);
        LTwo();
        yield return new WaitForSeconds(2f);
        LThree();
    }

    private void Update()
    {
    }

    private void LOne()
    {
        if (LPatternCheck <= LSequenceOne)
        {
            InvokeRepeating(nameof(SpawnLNotes), 0, 0.5f);
            LPatternCheck++;
        }
        else
        {
            LPatternCheck = 0;
            CancelInvoke(nameof(SpawnLNotes));
        }
    }

    private void LTwo()
    {
        if (LPatternCheck <= LSequenceTwo)
        {
            InvokeRepeating(nameof(SpawnLNotes), 2f, 1f);
            LPatternCheck++;
        }
        else
        {
            LPatternCheck = 0;
            CancelInvoke(nameof(SpawnLNotes));
        }
    }

    private void LThree()
    {
        if (LPatternCheck <= LSequenceThree)
        {
            InvokeRepeating(nameof(SpawnLNotes), 5f, 2f);
            LPatternCheck++;
        }
        else
        {
            LPatternCheck = 0;
            CancelInvoke(nameof(SpawnLNotes));
        }
    }

    //private void LOne()
    //{
    //    if (LPatternCheck <= LSequenceOne)
    //    {
    //        InvokeRepeating(nameof(SpawnLNotes), 0, 0.5f);
    //        LPatternCheck++;
    //    }
    //    else
    //    {
    //        LPatternCheck = 0;
    //        CancelInvoke(nameof(SpawnLNotes));
    //    }
    //}

    //private void LTwo()
    //{
    //    if (LPatternCheck <= LSequenceTwo)
    //    {
    //        InvokeRepeating(nameof(SpawnLNotes), 2f, 1f);
    //        LPatternCheck++;
    //    }
    //    else
    //    {
    //        LPatternCheck = 0;
    //        CancelInvoke(nameof(SpawnLNotes));
    //    }
    //}

    //private void LThree()
    //{
    //    if (LPatternCheck <= LSequenceThree)
    //    {
    //        InvokeRepeating(nameof(SpawnLNotes), 5f, 2f);
    //        LPatternCheck++;
    //    }
    //    else
    //    {
    //        LPatternCheck = 0;
    //        CancelInvoke(nameof(SpawnLNotes));
    //    }
    //}

    private void SpawnLNotes()
    {
        Instantiate(LNotes, LOrigin.transform.position, Quaternion.identity);
    }

    private void SpawnRNotes()
    {
        Instantiate(RNotes, ROrigin.transform.position, Quaternion.identity);
    }
}