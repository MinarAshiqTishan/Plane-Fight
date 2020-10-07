using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class pickupSpawn : MonoBehaviour
{

	public GameObject pickup;
	public int scoreValue;
	private gameController gc;
	// Use this for initialization

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("gc");
		if (gameControllerObject != null) {
			gc = gameControllerObject.GetComponent<gameController> ();
		}
		if (gc == null) {
			Debug.Log ("can't find gameController script");
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {
			//gamescore++;

			gc.AddScore (scoreValue);
			Instantiate (pickup, other.gameObject.transform.position, other.gameObject.transform.rotation);
			Debug.Log (other);
			Destroy (gameObject);
		} 
	}
	

}
