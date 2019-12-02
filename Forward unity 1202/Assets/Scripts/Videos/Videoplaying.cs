using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Videoplaying : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer _vp;

    void Start()
    {
      _vp.loopPointReached += LoadScene;
    }

    void LoadScene(VideoPlayer v)
    {
      SceneManager.LoadScene ("E2D");
    }


    // Update is called once per frame
    void Update()
    {

    }
}
