using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{

	public GameObject shot;
	public Transform shotspawn;
	public float delay, firerate;

	void Start ()
	{
		InvokeRepeating ("Fire", delay, firerate);
	}

	void Fire ()
	{
		Instantiate (shot, shotspawn.position, shotspawn.rotation);
		GetComponent<AudioSource> ().Play ();
	}
}
