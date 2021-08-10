using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float projectileDuration = 0;
 
	// Use this for initialization
	void Start () {
		Invoke ("Destroyed", projectileDuration);
		 
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	
	
	}

	void OnCollisionEnter (Collision col){
		
		if (col.gameObject.tag == "Asteroid") {
			Destroyed();
		}
		
	}
	
	void Destroyed(){
		print ("Projectile Destroyed : Projectile.cs");
		Destroy (this.gameObject); 
	}
}
