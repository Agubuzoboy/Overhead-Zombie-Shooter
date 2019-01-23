using UnityEngine;
using System.Collections;

public class GunSpawner : MonoBehaviour { 
	public guntokenscipt gun; 
	public float time; 
	public float maxTime;

	// Use this for initialization
	void Start () { 
		time = maxTime;
	
	}
	
	// Update is called once per frame
	void Update () { 

		if (time <= 0) { 
			Instantiate(gun,transform.position,transform.rotation);
			time = maxTime;
		} 

		time -= 1 * Time.deltaTime;
	
	}
}
