using UnityEngine;
using System.Collections;

public class guntokenscipt : MonoBehaviour {

	public float speed = 5; 
	public string gun; 
	public GameObject bullet; 
	public playermovementscript player; 
	public string gunmode; 
	public float gunfirerate; 
	public Sprite newplayersprite; 
	public Vector3 newshooterposition;
	public Vector3 newmuzzleposition; 
	public float newammo; 
	public float newreloadtime;
	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () { 

		rotate (); 


	} 

	public void rotate(){
		transform.Rotate(0, 1* speed * Time.deltaTime, 0);


	}   

	public void sendinfoanddie(){
		player.gun = this.gun; 
		player.bullet = this.bullet; 
		player.gunmode = this.gunmode; 
		player.gunfirerate = this.gunfirerate; 
		player.newplayersprite = this.newplayersprite; 
		player.newshooterposition = this.newshooterposition;
		player.newmuzzleposition = this.newmuzzleposition; 
		player.newammo = this.newammo;  
		player.ammo = this.newammo;
		player.newreloadtime = this.newreloadtime;
		Destroy(gameObject);
	}


	void OnTriggerEnter(Collider collider){

		if (collider.gameObject.tag == "Player") {

			player = collider.gameObject.GetComponent<playermovementscript>(); 
			sendinfoanddie();
		}


	}
}
