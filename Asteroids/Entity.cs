using UnityEngine;
using System.Collections;

public class Entity : MonoBehaviour {
	public int health = 0;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (health == 0) {
			Destroy(this.gameObject); 
		}
	}
}
