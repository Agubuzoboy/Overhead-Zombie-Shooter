using UnityEngine;
using System.Collections;

public class fatzombiescript : enemyscript {

	public float distancex; 
	public float distancez; 
	public float explodingpointx; 
	public float explodingpointz;
	// Use this for initialization
	void Start () {
	
		speed = 0.5f; 
		player = GameObject.FindGameObjectWithTag ("Player"); 
		enemyhealth = 10f; 
		returnspeed = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
	

		lookat (); 

		caculation ();

		if (distancex <= explodingpointx || distancez <= explodingpointz) {

			Debug.Log("execute explosion");
		}
	}  

	void FixedUpdate(){

		movetoplayer ();

	} 

	void caculation(){

		distancex = Mathf.Abs(player.transform.position.x - transform.position.x); 

		distancez = Mathf.Abs(player.transform.position.z - transform.position.z); 
	} 

	public void  OnCollisionEnter(Collision collision){
		
		if(collision.gameObject.tag == ("bullet")){ 
			enemypain = collision.collider.GetComponent<bulletscript>().damage;
			takedamage(); 
			Debug.Log (enemypain);
		}
		
	}

}

