using UnityEngine;
using System.Collections;

public class AsteroidBehavior : Entity {

	public float speed; 
	public bool isLarge = false; 
	public bool isMedium = false; 
	public bool isSmall = false; 
	private Asteroids asteroids; 
	
	public GameObject mediumPrefab; 
	public GameObject smallPrefab; 
	private Rigidbody rb;

	private float randX; 
	private float randz ; 
	private Vector3 randDirect;


	// Use this for initialization
	void Awake () {
		randX = Random.Range(0, 360); 
		randz = Random.Range(0, 360);
		randDirect = new Vector3(randX, 0, randz); 
		asteroids = GameObject.Find ("Main Camera").GetComponent<Asteroids> ();
		rb = this.GetComponent<Rigidbody> ();
	
	}

	void Start(){
		rb.velocity = transform.TransformDirection(randDirect * speed);
	}
	
	void OnCollisionEnter (Collision col){

		if (col.gameObject.tag == "Projectile") { 
			Destroyed (); 
		}
	}

	void Destroyed(){
		print ("Astroid hit : AsteroidBehavior.cs");
		asteroids.score += 10; 
		if(isLarge){
			Instantiate(mediumPrefab, transform.position, transform.rotation);
			Instantiate(mediumPrefab, transform.position, transform.rotation);
			Destroy (this.gameObject);
		}
		else if(isMedium){
			Instantiate(smallPrefab, transform.position, transform.rotation);
			Instantiate(smallPrefab, transform.position, transform.rotation); 
			Destroy (this.gameObject);
		}
		else if (isSmall){
			Destroy (this.gameObject);
		}
		print (asteroids.score); 
	}
}
