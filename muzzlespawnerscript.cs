using UnityEngine;
using System.Collections;

public class muzzlespawnerscript : MonoBehaviour {



	
	public Vector3 muzzleposition; 
	
	public Vector3 muzzledefaultposition;
	
	// Use this for initialization
	void Start () {
		
		muzzleposition = muzzledefaultposition;
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.localPosition = muzzleposition;
		
	}
}
