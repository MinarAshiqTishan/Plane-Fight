using UnityEngine;
using System.Collections;

public class protectContact : MonoBehaviour
{
	public GameObject explosion;

	void Start ()
	{
		Screen.SetResolution (500, 700, false);
	}
	//public Transform enemyLoc;
	// Use this for initialization
	void OnTriggerEnter (Collider other)
	{
			
		//Debug.Log (other);
		if (other.tag == "Boundary")
			return;
		//if (other.tag == "Enemy")
		//	Instantiate (enemyExplosion, transform.position, transform.rotation);
			
		if (other.tag != "Player") {
			Instantiate (explosion, transform.position, transform.rotation);
			if (other.tag != "bolt" && other.tag != "protection" && other.tag != "ss") {
					
				//Debug.Log (other);
				Destroy (gameObject);
					
				Destroy (other.gameObject);

			}
		}
			
	}
		
}
