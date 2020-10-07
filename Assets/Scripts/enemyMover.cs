using UnityEngine;
using System.Collections;

public class enemyMover : MonoBehaviour
{

	public float speed;
	private float move = 0.0f, moveright = 0.0f, moveleft = 0.0f, n = .1f;
	// Use this for initialization
	void Start ()
	{
		GetComponent<Rigidbody> ().velocity = transform.forward * speed;
		transform.localScale = new Vector3 (0, 0, 0);
		n = 0;
	}


	
	void FixedUpdate ()
	{
		n += Random.Range (0.001f, 0.03f);
		if (n > 2)
			n = 2;
		transform.localScale = new Vector3 (n, n, n);
		
		
		if (Input.GetKey ("up")) {
			move += 2f;
			GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, speed - move);
			n += 2f * Random.Range (0.001f, 0.03f);
			if (n > 2)
				n = 2;
			transform.localScale = new Vector3 (n, n, n);
		}
		if (Input.GetKey ("left")) {
			moveleft += 1f;
			GetComponent<Rigidbody> ().velocity = new Vector3 (moveleft, 0, speed - move);


		}
		if (Input.GetKey ("right")) {
			moveright += 1f;
			GetComponent<Rigidbody> ().velocity = new Vector3 (-moveright, 0, speed - move);
			
		}
		//if (Input.GetKey ("down")) {
		//	move = 0f;
		//}
		
	}
}