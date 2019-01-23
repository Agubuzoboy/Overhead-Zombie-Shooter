using UnityEngine;
using System.Collections;

public class bulletscript : MonoBehaviour {
	public float speed; 
	public float timer; 
	public float damage; 
	public GameObject player;
	// Use this for initialization
	void Start () {
	
		player = GameObject.FindGameObjectWithTag ("Player"); 


	}
	
	// Update is called once per frame
	void FixedUpdate () {
		moveforward (); 
		ignoreplayercollision ();
	} 



	public void ignoreplayercollision(){
		Physics.IgnoreCollision (player.GetComponent<Collider> (), gameObject.GetComponent<Collider> ());

	}

	public void moveforward(){ 

		GetComponent<Rigidbody> ().velocity = transform.forward * speed;  


		killaftertime ();
	}  

	void killaftertime(){

		timer -= 1 * Time.deltaTime; 

		if (timer <= 0) {

			GameObject.Destroy(gameObject);
		}
	}

	void OnCollisionEnter(Collision collision){

		GameObject.Destroy(gameObject);

	}
}
