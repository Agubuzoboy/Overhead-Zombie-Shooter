using UnityEngine;
using System.Collections;

public class shooterscript : MonoBehaviour { 


	public Vector3 position; 

	public Vector3 defualtposition;

	// Use this for initialization
	void Start () {
	
		position = defualtposition;
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.localPosition = position;

	}
}
