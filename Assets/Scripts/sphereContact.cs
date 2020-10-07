using UnityEngine;
using System.Collections;

public class sphereContact : MonoBehaviour
{
	public GameObject explosion;
	public GameObject enemyExplosion;
	public GameObject pickup;
	public GameObject bulletPow;
	//public Transform enemyLoc;
	// Use this for initialization
	void OnTriggerEnter (Collider other)
	{

		//Debug.Log (other);
		if (other.tag == "Boundary")
			return;
		if (other.tag == "Enemy")
			Instantiate (enemyExplosion, transform.position, transform.rotation);

		if (other.tag != "Player") {
			Instantiate (explosion, transform.position, transform.rotation);
			if (other.tag != "sbolt" && other.tag != "protection" && other.tag != "ss") {

				//Debug.Log (other);
				Destroy (gameObject);

				Destroy (other.gameObject);
				float R = Random.value;
				if (R > .7f)
					Instantiate (pickup, other.gameObject.transform.position, other.gameObject.transform.rotation);
				if (R < .05f)
					Instantiate (bulletPow, other.gameObject.transform.position, other.gameObject.transform.rotation);

			}
		}

	}
	
}
