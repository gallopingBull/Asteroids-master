using UnityEngine;
using System.Collections;

public class Asteroids : MonoBehaviour {

	public int lives = 3; 
	public int score = 0; 
	public int topScore = 0; 
	public float resetDelay = .1f;
	int i = 0; 

	public int maxClones = 4; 

	
	public GameObject shipPrefab;  
	private GameObject shipSpawnLocation; 
	private GameObject rSpawn; 
	public GameObject[]  cloneList;
	public GameObject[] asteroidsPrefabList;  
	public GameObject[] liveCubes;  


	
	
	// Use this for initialization
	void Awake () 
	{
		//cloneList = GameObject.FindGameObjectsWithTag ("Asteroid"); 
		shipSpawnLocation = GameObject.Find ("shipSpawnLocation"); 
		rSpawn = GameObject.Find ("asteroidRotation"); 
		//Setup();
	}

	void Update(){
		 
		cloneList = GameObject.FindGameObjectsWithTag ("Asteroid"); 
		if (cloneList.Length == 0) {
			for(int index = 0; index < maxClones; index++){
				Instantiate (asteroidsPrefabList[Random.Range(0, 3)], new Vector3(Random.Range(18, -18), 0, Random.Range(11, -11)), rSpawn.transform.rotation);  
				cloneList = GameObject.FindGameObjectsWithTag ("Asteroid"); 
			 
				//print("List Empty"); 
			}
		}
	}
	
	//Spawn the ship at the start of the game. 
	void Setup(){

		//Instantiate (shipPrefab, shipSpawnLocation.transform.position, shipSpawnLocation.transform.rotation);
	}	
	
	// Use this for initialization
	void Start () {

	}
	
	void OnGUI(){
		//GUI.Label(new Rect(100, 10, 100000, 30000000),""+ lives); 
		GUI.Label(new Rect(100, 30, 100, 30), "" + score); 	
		GUI.Label(new Rect(1000, 30, 100, 30), "" + topScore); 
	}
	
	void GameOver(){
		
		if (lives < 1) {
			Time.timeScale = .25f;
			Invoke ("Reset", resetDelay);		  
		} 
	}
	
	public void LoseLife(){
		lives--; 
		Destroy (liveCubes[i], .01f); 
		i++;
		//print ("Destroy Ball"); 
		GameOver (); 
		if (lives > 0) {
			Instantiate (shipPrefab, shipSpawnLocation.transform.position, shipSpawnLocation.transform.rotation); 
			//print ("instantiate ball"); 
		}
	}
	
	void Reset()
	{
		Time.timeScale = 1f;
		Application.LoadLevel ("test");
	}
	

}