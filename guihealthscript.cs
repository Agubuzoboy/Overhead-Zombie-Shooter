using UnityEngine; 
using UnityEngine.UI;
using System.Collections;

public class guihealthscript : MonoBehaviour { 

	public GameObject player;  
	public Sprite sprite;
	public Sprite lives3; 
	public Sprite lives2;
	public Sprite lives1;
	public Sprite lives0; 
	// Use this for initialization
	void Start () {
	
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {  

		  

		switch ((int)player.GetComponent<playermovementscript> ().lives) {

		case 3:  
			gameObject.GetComponent<Image> ().sprite = lives3; 
			break; 
		case 2: 
			gameObject.GetComponent<Image> ().sprite = lives2;
			break;  
		case 1: 
			gameObject.GetComponent<Image> ().sprite = lives1;
			break;  
		case 0: 
			gameObject.GetComponent<Image> ().sprite = lives0;
			break;

			}

		}

		
	
	}

