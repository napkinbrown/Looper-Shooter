using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

	public float speed;

	public Collider collider;
	public Rigidbody rb;
	
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		collider = GetComponent<Collider> ();

		rb.velocity = transform.up * speed;
	}
	
	void OnCollisionEnter(Collider other)
	{

	}
}
