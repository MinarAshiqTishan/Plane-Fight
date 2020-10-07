using UnityEngine;
using System.Collections;

public class pickupRotator : MonoBehaviour
{
	
	public GameObject pickup;
	
	public float x = 0.0f, y = 0.0f;
	private Vector3 offset, offset2;
	private float timer = .00f, factor = 1.0f, rfactor, ffactor;
	private float floatlength, floattime = .05f, rottimer;
	
	void Start ()
	{
		offset = transform.eulerAngles - pickup.transform.eulerAngles;
		floatlength = Random.value;
		//offset = transform.position - pickup.transform.position;
	}
	
	void LateUpdate ()
	{
		Vector3 rot = new Vector3 (x, 1.1f, 0);
		
		
		
		timer += floatlength * .002f;
		rottimer += .001f;
		factor = Mathf.Sin (timer * Mathf.Rad2Deg);
		if (floatlength - .5f < 0) {
			rfactor = Mathf.Sin (timer * Mathf.Rad2Deg);
			ffactor = Mathf.Cos (timer * Mathf.Rad2Deg);
		} else {
			ffactor = Mathf.Sin (timer * Mathf.Rad2Deg);
			rfactor = Mathf.Cos (timer * Mathf.Rad2Deg);
			
		}
		pickup.transform.Rotate (rot + offset);
		
		//transform.position.Set(Mathf.Abs (Mathf.Sin (timer*Mathf.Rad2Deg)),Vector3.up.y,0.0f);
		transform.position += Vector3.up * factor * floattime;
		transform.position += Vector3.right * ffactor * floattime;
		transform.position += Vector3.forward * rfactor * floattime;
		//transform.position -= Vector3.up * ((int)Time.realtimeSinceStartup % 2);
		
		
	}
}
