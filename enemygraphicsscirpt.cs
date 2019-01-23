using UnityEngine;
using System.Collections;

public class enemygraphicsscirpt : MonoBehaviour {

	public Color red;  
	public Color yellow;
	public Color white; 
	public float time; 
	public GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player"); 
	}
	
	// Update is called once per frame
	void Update () {
	
	} 

	IEnumerator changecolorwhenhurt(){

		GetComponent<SpriteRenderer>().color = red;  
		yield return new WaitForSeconds(0.1f); 
		GetComponent<SpriteRenderer>().color = white;  
		yield break;
	} 

	IEnumerator  colorchangewhenpaused(){

		GetComponent<SpriteRenderer>().color = yellow;  
		yield return new WaitForSeconds(1f);  
		GetComponent<SpriteRenderer>().color = white;   
		player.GetComponent<playermovementscript> ().ifrespawn = false;
		yield break;

	}
}
