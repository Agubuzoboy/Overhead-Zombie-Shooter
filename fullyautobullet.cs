using UnityEngine;
using System.Collections;

public class fullyautobullet : bulletscript {

	// Use this for initialization
	void Start () {
		speed = 15f; 
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
