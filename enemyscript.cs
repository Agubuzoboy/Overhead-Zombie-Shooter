using UnityEngine;
using System.Collections;

public class enemyscript : MonoBehaviour {

	public GameObject player; 
	public  float speed; 
	public float enemyhealth; 
	public bulletscript bullet; 
	public GameObject bulletgo;
	public float enemypain; 
	public enemygraphicsscirpt enemygraphic; 
	public float returnspeed;  
	public GameObject explosion; 
	public ScoreBoard scoreboard;

	// Use this for initialization
	void Start () {  
		speed = 1f;
		player = GameObject.FindGameObjectWithTag ("Player");  
		scoreboard = GameObject.FindObjectOfType<ScoreBoard> ();

	}
	
	// Update is called once per frame
	void Update () {
	  
		lookat (); 
	
		pause(); 





	}  

	void FixedUpdate(){

		movetoplayer ();  
		setSpeed ();

	
		Debug.Log (speed);
	}

	public void lookat(){

		transform.LookAt (player.transform.position, Vector3.up);

	}  

	public virtual void movetoplayer(){

		GetComponent<Rigidbody> ().velocity = transform.forward * speed;  

		//Debug.Log (speed);

		if (player.GetComponent<playermovementscript> ().ifrespawn) { 

			StartCoroutine ("pause"); 
			enemygraphic.StartCoroutine("colorchangewhenpaused");
		
		}

	} 

	public void takedamage (){ 
		enemygraphic.StartCoroutine ("changecolorwhenhurt");
		enemyhealth -= enemypain;  


		if (enemyhealth <= 0) { 
			Instantiate(explosion,transform.position,enemygraphic.transform.rotation); 
			scoreboard.addScore();
			Destroy(gameObject);
		}

	}   

	public void setSpeed(){
		this.speed = GameObject.FindObjectOfType<ArcadeModeScript> ().speed;
	}

	IEnumerator pause(){ 

		speed = 0; 
		yield return new WaitForSeconds(1f); 
		speed = returnspeed;  
		yield break;

	}

	public void  OnCollisionEnter(Collision collision){

		if(collision.gameObject.tag == ("bullet")){ 
			enemypain = collision.collider.GetComponent<bulletscript>().damage;
			takedamage();
		}

	} 




}
