using UnityEngine;
using System.Collections;

public class semiautobulletscript : bulletscript {

	// Use this for initialization
	void Start () {
		speed = 10f; 
		  timer = 6; 
		  damage = 5f;
		player = GameObject.FindGameObjectWithTag ("Player");  
	 }

	void FixedUpdate () {
		moveforward ();
		ignoreplayercollision ();
	} 
	
	// Update is called once per frame
	void Update () {
	
	} 

	void OnCollisionEnter(Collision collision){
		
		GameObject.Destroy(gameObject);
		
	}
}
