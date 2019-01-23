using UnityEngine;
using System.Collections; 
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour { 

	public int score;

	// Use this for initialization 

	void awake (){
		DontDestroyOnLoad (transform.gameObject);
	}
	void Start () { 
		score = 0; 

	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (score); 
		this.GetComponent<Text> ().text = score.ToString();
	} 

	public void addScore(){
		score += 1;
	}
}
