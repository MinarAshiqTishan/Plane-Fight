using UnityEngine;
using System.Collections;

public class DesstroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject playaExplosion;
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
	// Use this for initialization
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Boundary" || other.tag == "enemy")
			return;
	
		if (other.tag == "Player") {
			Instantiate (playaExplosion, other.transform.position, other.transform.rotation);
			gc.GameOver ();
		}
		if (other.tag != "Enemy") {
			Instantiate (explosion, transform.position, transform.rotation);
			if (other.tag != "bolt" && other.tag != "protection" && other.tag != "pickup") {
				//Debug.Log (other);
				Destroy (gameObject);
				Destroy (other.gameObject);
			}
		}
	}

}
