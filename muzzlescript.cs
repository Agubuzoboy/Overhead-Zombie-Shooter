using UnityEngine;
using System.Collections;

public class muzzlescript : MonoBehaviour {

	public float timetodie = 0.2f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Destroy (gameObject,timetodie);
	
	}
}
