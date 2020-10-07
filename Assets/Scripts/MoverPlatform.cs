using UnityEngine;
using System.Collections;

public class MoverPlatform : MonoBehaviour
{
	public float speed;
	private float move = 0.0f, moveright = 0.0f, moveleft = 0.0f, moveup = 0.0f, x = 0.1f, y = 0.1f, z = 0.1f, n = .4f;
	// Use this for initialization
	void Start ()
	{
		GetComponent<Rigidbody> ().velocity = transform.forward * (speed);
		transform.localScale = new Vector3 (0, 0, 0);
		x = 0;
		y = 0;
		z = 0;
	}
	
	
	void FixedUpdate ()
	{
		x += n;
		y += n;
		z += n;
		if (x >= 14f)
			x = 14f;
		if (y >= 1f)
			y = 1f;
		if (z >= 3f)
			z = 3f;


		transform.localScale = new Vector3 (x, y, z);
		if (Input.GetKey ("up")) {
			move += 5f;
			GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, speed - move);
			x += n;
			y += n;
			z += n;
			if (x >= 14f)
				x = 14f;
			if (y >= 1f)
				y = 1f;
			if (z >= 2f)
				z = 2f;

			transform.localScale = new Vector3 (x, y, z);



		}

		if (Input.GetKey ("left")) {
			moveleft += 1f;
			GetComponent<Rigidbody> ().velocity = new Vector3 (moveleft, 0, speed - move);
			
		}
		if (Input.GetKey ("right")) {
			moveright += 1f;
			GetComponent<Rigidbody> ().velocity = new Vector3 (-moveright, 0, speed - move);
			
		}
		if (Input.GetKey ("down")) {
			move = 0f;
		}
		
	}
	
}
