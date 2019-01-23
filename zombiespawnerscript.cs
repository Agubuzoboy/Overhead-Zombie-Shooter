 using UnityEngine;
using System.Collections;

public class zombiespawnerscript : enemyspawnerscript {

	// Use this for initialization
	void Start () {

		 timer = 10;
		 restarttime = 10; 
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
