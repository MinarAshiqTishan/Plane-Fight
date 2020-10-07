using UnityEngine;
using System.Collections;

public class rotator : MonoBehaviour
{

	
	public float tumble;
	
	void Start ()
	{
		GetComponent<Rigidbody> ().angularVelocity = new Vector3 (0, 0, 30) * tumble;	
	}
}
