using UnityEngine;
using System.Collections;

public class gameController : MonoBehaviour
{

	public GameObject[] hazards;

	public GameObject platform;
	public Vector3 spawnValues, spawnValuesPlatform;
	public float spawnWait, startWait, waveWait, spawnWaitPlatform, spawnWaitAsteroids;
	private int levelOfhazards = 3;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameoverText;
	public GUIText highscoreText;
	private int score, highscore;
	public bool restart;
	public bool gameover;
	string highScoreKey = "HighScore";
	// Use this for initialization
	void Start ()
	{
		score = 0;
		highscore = PlayerPrefs.GetInt (highScoreKey, 0);
		UpdateScore ();
		StartCoroutine (spawnPlatform ());
		StartCoroutine (spawnHazards ());
		StartCoroutine (spawnAsteroids ());
		restart = false;
		gameover = false;
		restartText.text = "";
		gameoverText.text = "";
	}

	void Update ()
	{
		if (score >= highscore) {
			PlayerPrefs.SetInt (highScoreKey, score);
			PlayerPrefs.Save ();
			highscore = PlayerPrefs.GetInt (highScoreKey, 0);
		}
		if (restart) {
			if (Input.GetKeyDown (KeyCode.R))
				Application.LoadLevel (Application.loadedLevel);
		}
	}

	IEnumerator spawnAsteroids ()
	{
		//yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i=0; i<3; i++) {
				GameObject hazard = hazards [Random.Range (0, 3)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), 0f, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), Random.Range (-spawnValues.y, -1.5f), spawnValues.z);
				spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWaitAsteroids);
			}

			
			yield return new WaitForSeconds (waveWait);
		}
	}

	IEnumerator spawnPlatform ()
	{
		//yield return new WaitForSeconds (startWait);
		while (true) {
			while (true) {
				Vector3 spawnPosition = new Vector3 (spawnValuesPlatform.x, spawnValuesPlatform.y, spawnValuesPlatform.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (platform, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWaitPlatform);
			}

		}
	}
	IEnumerator spawnHazards ()
	{
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i=0; i<50; i++) {

				if (score <= 30)
					levelOfhazards = 3;
				else if (score > 30 && score <= 90)
					levelOfhazards = 4;
				else if (score > 90 && score < 120)
					levelOfhazards = 5;
				else if (score > 120)
					levelOfhazards = hazards.Length;

				GameObject hazard = hazards [Random.Range (1, levelOfhazards)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), Random.Range (-spawnValues.y, spawnValues.y), spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
				if (gameover) {
					restartText.text = "To Return to Main Menu Press 'R'";
					restart = true;
					break;
				}
			}
			yield return new WaitForSeconds (waveWait);
			if (gameover) {
				restartText.text = "To Return to Main Menu Press 'R'";
				restart = true;
				break;
			}

		}


	}

	void UpdateScore ()
	{
		scoreText.text = "Score : " + score.ToString ();
		if (score >= highscore) {
			PlayerPrefs.SetInt (highScoreKey, score);
			PlayerPrefs.Save ();
			highscore = PlayerPrefs.GetInt (highScoreKey, 0);
		}
		highscoreText.text = "High Score : " + highscore.ToString ();
	}

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();

	}


	public void GameOver ()
	{
		gameoverText.text = "Game Over";
		gameover = true;
	}
}
