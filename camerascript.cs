using UnityEngine;
using System.Collections;

public class camerascript : MonoBehaviour { 

	public Vector3 position;  
	public GameObject player; 

		 

	// Use this for initialization
	void Start () { 
		transform.eulerAngles = new Vector3 (90,0,0);  
		 player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () { 
	
	} 

	void FixedUpdate(){
		position = new Vector3 (player.transform.position.x, 10, player.transform.position.z); 
		transform.position = position;

		
		transform.eulerAngles = new Vector3 (90,0,0); 
	}
}
