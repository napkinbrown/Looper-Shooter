using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Rigidbody rb;
	public float maxSpeed = 10f;
	public float maxTurning = 2;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	
	private float nextFire;

	[System.Serializable]
	public class Boundary
	{
		public float xMin, xMax, yMin, yMax;
	}

	void Start()
	{
		rb.GetComponent<Rigidbody> ();
	}

	void Update ()
	{
		if (Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
		}
	}

	void FixedUpdate()
	{
		float speed = Input.GetAxis ("Vertical") * maxSpeed * Time.deltaTime;
		float turning = Input.GetAxis ("Horizontal") * maxTurning * Time.deltaTime;

		if (Input.GetKey("left")== false && Input.GetKey("right") == false) { //stops turning momentum when they let go of the button
			rb.angularVelocity = Vector3.zero;
		} 

		rb.AddForce (transform.up * speed, ForceMode.Acceleration);
		rb.AddTorque (transform.forward * turning * -1); //-1 makes it turn the right way

		rb.position = new Vector3 //Sets boundaries
			(
				Mathf.Clamp (GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax), 
				Mathf.Clamp (GetComponent<Rigidbody>().position.y, boundary.yMin, boundary.yMax),
				0.0f 

				);

	}
}
