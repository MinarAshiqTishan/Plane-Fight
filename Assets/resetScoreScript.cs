using UnityEngine;
using System.Collections;

public class resetScoreScript : MonoBehaviour
{
	string highScoreKey = "HighScore";
	// Use this for initialization
	void Start ()
	{
		PlayerPrefs.SetInt (highScoreKey, 0);
		PlayerPrefs.Save ();
	}
	

}
