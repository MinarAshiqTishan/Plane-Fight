using UnityEngine;
using System.Collections;

public class movershot2 : MonoBehaviour
{
	public float speed;
	private float move = 0.0f, moveright = 0.0f, moveleft = 0.0f, moveup = 0.0f;
	// Use this for initialization
	
	
	void FixedUpdate ()
	{
		GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
		
		if (Input.GetKey ("up")) {
			move += 1f;
			GetComponent<Rigidbody> ().velocity = new Vector3 (0, 0, 0);
		}
		if (Input.GetKey ("left")) {
			moveleft = 7f;
			GetComponent<Rigidbody> ().velocity = new Vector3 (-moveleft, 0, 0);
			
		}
		if (Input.GetKey ("right")) {
			moveright = 7f;
			GetComponent<Rigidbody> ().velocity = new Vector3 (moveright, 0, 0);
			
		}
		//if (Input.GetKey ("down")) {
		//	move = 0f;
		//}
		GetComponent<Rigidbody> ().position = new Vector3
			(
				Mathf.Clamp (GetComponent<Rigidbody> ().position.x, -5f, 5f),
				0.0f,
				0f
		);
	}
	
}