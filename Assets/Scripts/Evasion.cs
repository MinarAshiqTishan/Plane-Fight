using UnityEngine;
using System.Collections;

public class Evasion : MonoBehaviour
{
	public Boundary boundary;
	public float tilt;
	public float dodge;
	public float smoothing;
	public Vector2 startWait;
	public Vector2 maneuverTime;
	public Vector2 maneuverWait;

	private float currentSpeed;
	private float targetManeuver;

	public float speed;
	private float move = 0.0f, moveright = 0.0f, moveleft = 0.0f, moveup = 0.0f, n = .1f;
	// Use this for initialization
	void Start ()
	{
		currentSpeed = GetComponent<Rigidbody> ().velocity.z;
		StartCoroutine (Evade ());
		GetComponent<Rigidbody> ().velocity = transform.forward * (speed);
		transform.localScale = new Vector3 (0, 0, 0);
		n = 0;

	}


	IEnumerator Evade ()
	{
		yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));
		while (true) {
			targetManeuver = Random.Range (1, dodge) * -Mathf.Sign (transform.position.x);
			yield return new WaitForSeconds (Random.Range (maneuverTime.x, maneuverTime.y));
			targetManeuver = 0;
			yield return new WaitForSeconds (Random.Range (maneuverWait.x, maneuverWait.y));
		}
	}

	
	void FixedUpdate ()
	{
		float newManeuver = Mathf.MoveTowards (GetComponent<Rigidbody> ().velocity.x, targetManeuver, smoothing * Time.deltaTime);
		GetComponent<Rigidbody> ().velocity = new Vector3 (newManeuver, 0.0f, currentSpeed);
		GetComponent<Rigidbody> ().position = new Vector3
			(
				Mathf.Clamp (GetComponent<Rigidbody> ().position.x, boundary.xMin, boundary.xMax), 
				0.0f, 
				Mathf.Clamp (GetComponent<Rigidbody> ().position.z, boundary.zMin, boundary.zMax)
		);
		
		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0, 0, GetComponent<Rigidbody> ().velocity.x * -tilt);

//		n += Random.Range (0.001f, 0.03f);
//		if (n > 2)
//			n = 2;
//		transform.localScale = new Vector3 (n, n, n);
		
		
//		if (Input.GetKey ("up")) {
//			move -= 2f;
//			GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, -speed + move);
//			n += 2f * Random.Range (0.001f, 0.03f);
//			if (n > 2)
//				n = 2;
//			transform.localScale = new Vector3 (n, n, n);
//
//		}
//		if (Input.GetKey ("left")) {
//			moveleft += 1f;
//			GetComponent<Rigidbody> ().velocity = new Vector3 (moveleft, 0, -speed + move);
//			
//		}
//		if (Input.GetKey ("right")) {
//			moveright += 1f;
//			GetComponent<Rigidbody> ().velocity = new Vector3 (-moveright, 0, -speed + move);
//			
//		}
//		if (Input.GetKey ("down")) {
//			move = 0f;
//		}
//		
	}
	
}