using UnityEngine;
using System.Collections;

public class zombiescript : enemyscript {

	// Use this for initialization
	void Start () {
		//speed = 1f; 
		player = GameObject.FindGameObjectWithTag ("Player"); 
		enemyhealth = 5f;  
		returnspeed = 1f; 
		scoreboard = GameObject.FindObjectOfType<ScoreBoard> (); 
		setSpeed ();

	}
	
	// Update is called once per frame
	void Update () {
		

		lookat (); 

	}  
	
	void FixedUpdate(){ 



	
		movetoplayer ();
		
	} 
	public void  OnCollisionEnter(Collision collision){
		
		if(collision.gameObject.tag == ("bullet")){
			enemypain = collision.collider.GetComponent<bulletscript>().damage;
			takedamage();
		}
		
	} 


		


}
