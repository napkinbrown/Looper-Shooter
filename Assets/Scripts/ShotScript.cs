using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

	public float speed;
	public float timer; //in seconds

	public Collider collider;
	public Rigidbody rb;
	
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
		collider = GetComponent<Collider> ();

		rb.velocity = transform.up * speed;
	}

	void Update()
	{
		timer -= Time.deltaTime;

		if (timer <= 0) 
		{
			Destroy(gameObject);
		}
	}
	/* void OnCollisionEnter(Collider other)
	{
		//this is for destroying the object the shot hits
	} */
}
