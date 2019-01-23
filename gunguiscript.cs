using UnityEngine;
using System.Collections; 
using UnityEngine.UI;

public class gunguiscript : MonoBehaviour {

	public GameObject player; 
	public Sprite semiautogungui; 
	public Sprite fullyautogungui;
	// Use this for initialization
	void Start () {
	
		player = GameObject.FindGameObjectWithTag ("Player"); 


	}
	
	// Update is called once per frame
	void Update () {
	
		switch (player.GetComponent<playermovementscript> ().gun) {

		case "semiauto":
			gameObject.GetComponent<Image> ().sprite = semiautogungui;
			break; 

		case "fullyauto": 
			gameObject.GetComponent<Image> ().sprite = fullyautogungui;
			break; 
			

		}

	}
}
