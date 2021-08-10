using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {
		
	public float MinX;
	public float MaxX;
	public float MinZ;
	public float MaxZ; 

	// Use this for initialization
	void Start () {
	
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float x = transform.position.x; 
		float Z = transform.position.z; 

		if (x < MinX) {
			x = MaxX; 
		} else if (x > MaxX) {
			x = MinX; 
		}

		if (Z < MinZ) {
			Z = MaxZ; 
		} else if (Z > MaxZ) {
			Z = MinZ; 
		}

		transform.position = new Vector3 (x, transform.position.y, Z);  
	}
}
