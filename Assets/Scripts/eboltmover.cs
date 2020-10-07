using UnityEngine;
using System.Collections;

public class eboltmover : MonoBehaviour
{

	public float speed;
	private float move = -1f, moveright = 0.0f, moveleft = 0.0f, n = .1f;
	void Start ()
	{
		GetComponent<Rigidbody> ().velocity = transform.forward * speed;
	}


	void FixedUpdate ()
	{

		if (Input.GetKey ("up")) {
			move -= .5f;
			GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, speed * move);
	
		}

		if (Input.GetKey ("left")) {
			moveleft += 1f;
			GetComponent<Rigidbody> ().velocity = new Vector3 (moveleft, 0, speed * move);
		
		}
		if (Input.GetKey ("right")) {
			moveright += 1f;
			GetComponent<Rigidbody> ().velocity = new Vector3 (-moveright, 0, speed * move);
		
		}
		if (Input.GetKey ("down")) {
			move = 0f;
		}
	
	}
}