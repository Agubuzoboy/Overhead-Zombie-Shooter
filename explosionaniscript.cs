﻿using UnityEngine;
using System.Collections;

public class explosionaniscript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (gameObject, 0.3f);
	}
}
