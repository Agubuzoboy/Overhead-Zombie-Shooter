using UnityEngine;
using System.Collections;

public class fullyautoguntokenscript : guntokenscipt {


	// Use this for initialization
	void Start () {
		gunfirerate = 0.8f;
		 
	}
	
	// Update is called once per frame
	void Update () {
	
		rotate (); 

	} 


	
	void OnTriggerEnter(Collider collider){
		
		if (collider.gameObject.tag == "Player") {
			
			player = collider.gameObject.GetComponent<playermovementscript>(); 
			sendinfoanddie();
		}
		
		
	}
}
