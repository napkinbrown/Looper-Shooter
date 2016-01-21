using UnityEngine;
using System.Collections;

public class ShotScript : MonoBehaviour {

	public float speed;
	public float timer; //in seconds
	
	public Rigidbody rb;
	
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
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
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Boundary")
		{
			Destroy(gameObject);
			return;
		}

		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
