using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScore : MonoBehaviour
{
	//new update
    // Start is called before the first frame update
	public int ScoreCon = 0;
	public bool preScore = false;
	public int combo = 0;
	//display combo and score
	public Text ScoreDisplay;
  public Text ComboDisplay;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

	//collision
	void onCollisonEnter(Collision other)
	{
		//check combo left
		if (preScore && Input.GetKeyDown("left")) {
			ScoreCon = ScoreCon+1;
			preScore = true;
			combo = combo + 1;
		}
		else if (Input.GetKeyDown("left"))
		{
			ScoreCon = ScoreCon+1;
			preScore = true;
		}
		else
		{
				preScore = false;
		}

		//check combo right
		if (preScore && Input.GetKeyDown("right")) {
			ScoreCon = ScoreCon+1;
			preScore = true;
			combo = combo + 1;
		}
		else if (Input.GetKeyDown("right"))
		{
			ScoreCon = ScoreCon+1;
			preScore = true;
		}
		else
		{
				preScore = false;
		}

		SetCountText ();

	}

	void SetCountText ()
    {
        ScoreDisplay.text = "Score: " + ScoreCon.ToString ();
				ComboDisplay.text = "Combo: " + combo.ToString ();
    }

}
