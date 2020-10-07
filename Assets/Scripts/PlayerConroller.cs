using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}


public class PlayerConroller : MonoBehaviour
{

	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot, asteroid, platform, shot2, flare;
	public Transform shotspawn;
	public ParticleSystem emit1, emit2;

	public float fireRate = 0.5f;
	private float nextfire = 0.1f;

	void Start ()
	{

		Screen.SetResolution (500, 700, false);
	}

	void Update ()
	{
		if (Input.GetButton ("Fire1") && Time.time > nextfire) {
			nextfire = Time.time + fireRate;
			//GameObject clone = 
			Instantiate (shot, shotspawn.position, shotspawn.rotation);
			//as GameObject; //to initiate an object to work with
			GetComponent<AudioSource> ().Play ();
		}
		if (Input.GetButtonDown ("Jump") && Time.time > nextfire) {
			nextfire = Time.time + fireRate;
			//GameObject clone = 
			Instantiate (shot2, shotspawn.position, shotspawn.rotation);

			//as GameObject; //to initiate an object to work with
			GetComponent<AudioSource> ().Play ();
		}

//		if (Time.time > nextfire) {
//			nextfire = Time.time + fireRate;
//			//GameObject clone = 
//			Instantiate (asteroid, new Vector3 (Random.value, Random.value, Random.value), transform.rotation);
//			//as GameObject; //to initiate an object to work with
//
//		}
	}


	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0f, 0f);
		GetComponent<Rigidbody> ().velocity = movement * speed;
		emit1.startSize = 0f;
		emit2.startSize = 0f;
		//emit1.transform.position = new Vector3 (flare.transform.position.x, flare.transform.position.y,  flare.transform.position.z);
		//emit2.transform.position = new Vector3 (flare.transform.position.x, flare.transform.position.y, -2f);
		
		GetComponent<Rigidbody> ().position = new Vector3
		(
				Mathf.Clamp (GetComponent<Rigidbody> ().position.x, boundary.xMin, boundary.xMax),
				0.0f,
				Mathf.Clamp (GetComponent<Rigidbody> ().position.z, boundary.zMin, boundary.zMax)
		);
		GetComponent<Rigidbody> ().rotation = Quaternion.Euler (0.0f, 0.0f, GetComponent<Rigidbody> ().velocity.x * -tilt);

		if (Input.GetKey ("up")) {
			emit1.startSize = 1f;
			emit2.startSize = 1f;
			//emit1.transform.position = new Vector3 (flare.transform.position.x, flare.transform.position.y, -1.5f);
			//emit2.transform.position = new Vector3 (flare.transform.position.x, flare.transform.position.y, -1.5f);
		}
	}

	public void AddPow (float pow)
	{
		if (fireRate > 0.14f)
			fireRate -= pow;
		if (fireRate <= 0.14f)
			fireRate = .15f;
		//	UpdateScore ();
		
	}
}
