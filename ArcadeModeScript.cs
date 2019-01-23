using UnityEngine;
using System.Collections;

public class ArcadeModeScript : MonoBehaviour { 

	public float speed = 1f; 
	public zombiescript zs; 



	void awake (){

	}
	// Use this for initialization
	void Start () {
		speed = 1; 
		//DontDestroyOnLoad (gameObject);  


	}
	
	// Update is called once per frame
	void Update () {  
		zs = GameObject.FindObjectOfType<zombiescript> (); 
		if (!(zs == null)) {
			addSpeed (); 
			//Debug.Log (speed);
		} 
	


	} 

	void addSpeed(){ 
		speed += 0.0625f * Time.deltaTime;
	}

}
