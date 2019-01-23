using UnityEngine;
using System.Collections;

public class fatzombiespawner : enemyspawnerscript {

	// Use this for initialization
	void Start () {
	
		timer = 20;
		restarttime = 20; 
		timer = restarttime;
		
	}
	
	// Update is called once per frame
	void Update () { 
		
		
		
		timedec ();
		
		if (timer <= 0) {
			spawn();
		}
	}
}
