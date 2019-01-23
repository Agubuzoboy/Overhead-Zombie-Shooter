using UnityEngine;
using System.Collections;

public class enemyspawnerscript : MonoBehaviour { 

	public GameObject enemy; 
	public float timer;
	public float restarttime;

	// Use this for initialization
	void Start () {
		timer = restarttime;
	}
	
	// Update is called once per frame
	void Update () { 
		timedec (); 

		if (timer <= 0) {
			spawn();
		}

	
	} 

	public void spawn (){

		Instantiate (enemy, transform.position, Quaternion.identity);  
		//Debug.Log ("spawn");
		timer = restarttime;
	} 

	public void timedec (){

		timer -= 1 * Time.deltaTime;
	}
}
