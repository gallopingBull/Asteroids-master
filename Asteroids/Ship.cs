using UnityEngine;
using System.Collections;

public class Ship : Entity {
	public float accelerationForce = 10f;
	public float rotationForce = 3f;
	public GameObject projectileSpawnLoc; 
	public Rigidbody projectile; 
	private Rigidbody rb; 
	private Asteroids asteroids; 


	// Use this for initialization
	void Awake () {
		asteroids = GameObject.Find ("Main Camera").GetComponent<Asteroids> (); 
		rb = this.gameObject.GetComponent<Rigidbody> (); 
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float rotation = Input.GetAxis("Horizontal");
		float acceleration = Input.GetAxis("Vertical");
		rb.AddTorque(0, rotation * rotationForce, 0); 
		rb.AddForce(transform.forward * acceleration * accelerationForce);

		if (Input.GetKeyDown ("space")) {
			Invoke("Shoot", .5f); 
		}
	}

	void Shoot(){
		print ("Shooting");
		Rigidbody clone;
		clone = Instantiate(projectile, projectileSpawnLoc.transform.position, transform.rotation) as Rigidbody;
		clone.velocity = transform.TransformDirection(Vector3.forward * 10);
	}
	void OnCollisionEnter (Collision col){
			
		if (col.gameObject.tag == "Asteroid") {
			asteroids.LoseLife (); 
			health--; 
			print("Touched Asteroid: Ship.cs");
			Destroy(this.gameObject);
		}
		
	}

}
