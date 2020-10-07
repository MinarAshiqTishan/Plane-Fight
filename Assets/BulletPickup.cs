using UnityEngine;
using System.Collections;

public class BulletPickup : MonoBehaviour
{

	public GameObject Bulletpickup;
	public float pow;
	private PlayerConroller pc;
	// Use this for initialization
	
	void Start ()
	{
		GameObject playerControllerObject = GameObject.FindGameObjectWithTag ("Player");
		if (playerControllerObject != null) {
			pc = playerControllerObject.GetComponent<PlayerConroller> ();
		}
		if (pc == null) {
			Debug.Log ("can't find playerController script");
		}
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player") {
			//gamescore++;
			
			pc.AddPow (pow);
			Instantiate (Bulletpickup, other.gameObject.transform.position, other.gameObject.transform.rotation);
			Debug.Log (other);
			Destroy (gameObject);
		} 
	}
	
	
}
