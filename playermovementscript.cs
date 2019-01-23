using UnityEngine;
using System.Collections;

public class playermovementscript : MonoBehaviour { 

	public float movementspeed = 5f; 
	public float bulletspeed  = 10f;
	public float movementspeeddiag = 3.5f;
	public GameObject bullet; 
	public GameObject muzzle;
	public GameObject shooter;  
	public GameObject muzzlespawner;
	public Vector3 target;  
	public Camera camera;  
	public float lives = 3; 
	public Vector3 respawnpoint; 
	public bool ifrespawn; 
	public string gun; 
	public GameObject semiautobullet; 
	public float tokencountdown = 10; 
	public string gunmode; 
	public float firerate; 
	public float gunfirerate;
	public Sprite newplayersprite; 
	public playersprite playerspriteref; 
	public Sprite defualtsprite; 
	public Vector3 newshooterposition; 
	public Vector3 defaultshooterposition; 
	public shooterscript shooterscriptref; 
	public Vector3 newmuzzleposition; 
	public Vector3 defaultmuzzleposition;
	public muzzlespawnerscript muzzlescriptref; 
	public float newammo; 
	public float defaultammo; 
	public float newreloadtime; 
	public float defaultreloadtime; 
	public float ammo; 
	public float reloadtime; 
	public Vector3 lerptarget; 
	public float rotatespeed;
	public Vector3 move;


	// Use this for initialization
	void Start () {  
		//sets lives
		lives = 3;  
		//sets default gun
		gun = "semiauto"; 
		//sets default gunmode
		gunmode = "semi automatic fire";  
		//sets defualt ammo
		ammo = defaultammo;  
		//sets  default reload time
		reloadtime = defaultreloadtime;
		// sets shooter gameobject defualt position
		this.defaultshooterposition = shooterscriptref.defualtposition;
	}
	
	// Update is called once per frame
	void Update () {
	  


		//call movement function in every frame
		movement (); 
		cheekguntoken (); 
		fireratecounter (); 

		//cheeks if theres no ammo if theres no ammo calls reload method
		if (ammo <= 0) {
			reload();
		}



		// cheek for input of f in every frame if true execute shoot function
		if (gunmode == "semi automatic fire") {
			if ((Input.GetKeyDown (KeyCode.F) || Input.GetButtonDown ("Fire1"))&& firerate <= 0 && ammo > 0) {
				shoot (); 
			}
		} 

		//  checks for holding input of f and if its a fully automatic fire gun if f is holded shoot in rapid fire
		if (gunmode == "fully automatic fire") {
			if ((Input.GetKey(KeyCode.F) || Input.GetButton("Fire1")) && firerate <= 0 && ammo > 0) {
				shoot (); 
			}

		}

} 

	void FixedUpdate(){ 
		// sets target to mouse position in the real world 
		target = camera.ScreenToWorldPoint (new Vector3(Input.mousePosition.x,Input.mousePosition.y,camera.transform.position.y - transform.position.y));
		// makes player look at target varible
		transform.LookAt (target,Vector3.up); 
		// moves player acording to axis multiplied by movement speed
		GetComponent<Rigidbody> ().velocity = new Vector3 (Input.GetAxisRaw ("Horizontal") * movementspeed,2, Input.GetAxisRaw ("Vertical") * movementspeed);
		 
		// checks if player is moving diognally if so it adjustes speed
		if (gameObject.GetComponent<Rigidbody> ().velocity.x != 0 && gameObject.GetComponent<Rigidbody> ().velocity.z != 0) {
			gameObject.GetComponent<Rigidbody>().velocity = new Vector3(Input.GetAxisRaw("Horizontal")*movementspeeddiag ,2,Input.GetAxisRaw("Vertical")*movementspeeddiag); 
			 } 

		if (gameObject.GetComponent<Rigidbody> ().position.x < -6.10f) {
			gameObject.GetComponent<Rigidbody> ().position = new Vector3(-6.10f,2,gameObject.GetComponent<Rigidbody>().position.z);
		}  
		if (gameObject.GetComponent<Rigidbody> ().position.x > 6.10f) {
			gameObject.GetComponent<Rigidbody> ().position = new Vector3(6.10f,2,gameObject.GetComponent<Rigidbody>().position.z);
		}  
		if (gameObject.GetComponent<Rigidbody> ().position.z < -4.25f) {
			gameObject.GetComponent<Rigidbody> ().position = new Vector3(gameObject.GetComponent<Rigidbody>().position.x,2,-4.25f);
		}  
		if (gameObject.GetComponent<Rigidbody> ().position.z > 4.25f) {
			gameObject.GetComponent<Rigidbody> ().position = new Vector3(gameObject.GetComponent<Rigidbody>().position.x,2,4.25f);
		} 
		/*if (gameObject.GetComponent<Rigidbody> ().position.x >= 6.5f) {
			gameObject.GetComponent<Rigidbody> ().position.x = 6.5f;
		}*/

	}


	void movement(){

		// makes refrence to gameobjects rigidbody and makes its velocity varible to equal values of axis x and y

		//if (gameObject.GetComponent<Rigidbody> ().velocity.x != 0 && gameObject.GetComponent<Rigidbody> ().velocity.z != 0) {
			//gameObject.GetComponent<Rigidbody>().MovePosition = new Vector3(Input.GetAxisRaw("Horizontal")*movementspeeddiag ,0,Input.GetAxisRaw("Vertical")*movementspeeddiag); 
		//}

	// makes vector 3 type target equall to mouse position on pixial cordinates converted in to real world coordniates


		//Vector3 newtarget = target - transform.position;

		//lerptarget = Vector3.Lerp (transform.eulerAngles,newtarget, 100);
		// states the vector 3 values of target 

		// makes object local z face target and iniziates up axis 

		//Quaternion rotation = Quaternion.LookRotation (newtarget, Vector3.up); 

		//transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle (transform.eulerAngles.y, rotation.eulerAngles.y, rotatespeed * Time.deltaTime);


	}  



	void shoot(){  
		// makes a copy of bullet in position of sooter with rotaton
		Instantiate(bullet,shooter.transform.position,shooter.transform.rotation);  
		//makes copy of muzzle 
		Instantiate(muzzle,muzzlespawner.transform.position,muzzlespawner.transform.rotation);  
		//makes firerate equall to the full fire rate to controll amount of times player can shoot
		firerate = gunfirerate;   
		//subtracts one ammo
		//ammo -= 1;



	}     

	void reload(){ 
		// subtracts from reload time each second
		reloadtime -= 1 * Time.deltaTime;   
		// when reload time equall zero and if gun is the defualt semi auto gun then set ammo to defualt ammo and reloadtime back to defualt reload time 
		if (reloadtime <= 0) { 
			if(gun == "semiauto"){
				ammo = defaultammo; 
				reloadtime = defaultreloadtime;
			}  
			// if it is not the defualt gun set ammo to newammo and reloadtime to new reloadtime
			else{
			ammo = newammo; 
				reloadtime = newreloadtime;}

		} 



	}

	void fireratecounter(){

		//if fire is greater than 0 subtract 1 so player can shoot when its zero
		if(firerate > 0){ 
			firerate -= 10 * Time.deltaTime;
		}
	}


	void cheekguntoken(){

		//if player has defualt gun set the bullet to its defualt bullet set the gunmode to semi automatic fire set the gunfirerate to 1 and set the newreloadtime to defualt reload time
		if (gun == "semiauto") {


			bullet = semiautobullet; 
			gunmode = "semi automatic fire"; 
			gunfirerate = 1;  
			newreloadtime = defaultreloadtime;

		} 

		// if player has another gun then...
		if (gun != "semiauto") { 

			//start tokencountdonmethod
			tokencountdowntimer ();
			//change player graphic to new player graphic to reprsent new gun
			playerspriteref.playerspritegraphic = newplayersprite;  
			// change shooter gameobject position depnding on gun
			shooterscriptref.position = newshooterposition; 
			//change muzzle position depending on gun
			muzzlescriptref.muzzleposition = newmuzzleposition; 
		} else { //if player has no powerup...
			//leave tokencountdown as 10 because he has no power up
			tokencountdown = 10; 
			// leave player graphic as defualt
			playerspriteref.playerspritegraphic = defualtsprite;  
			//leave shooter gameobject in defualt position 
			shooterscriptref.position = defaultshooterposition;  
			//leave muzzle position in defualt position
			muzzlescriptref.muzzleposition = defaultmuzzleposition; 

		}

		//if tokencountdown goes down to zero
		if(tokencountdown <= 0){ 
			// turn gun back to defualt gun
			gun = "semiauto";  
			//reset ammo back to defualt ammo
			ammo = defaultammo;  
			// reset reloadtime to defualt reload time
			reloadtime = defaultreloadtime;
		}

	} 

	void tokencountdowntimer(){

		// subtract 1 from tokencountdown every second
		tokencountdown -= 1 * Time.deltaTime;
		
	} 



	

	 bool respawn (){

		// subtract 1 life when player respawns
		lives -= 1;   
		//telport player to respawn point
		transform.position = respawnpoint;  
		//set gun back to defualt gun
		gun = "semiauto";   
		// set ammo to defualt ammo
		ammo = defaultammo; 
		//print respwawned
		Debug.Log ("respawned");  
		// call gameover when lives is less than or equall to zero
		if(lives <= 0) {
			gameover();  
		}  
		//returns a true value 
		return true;

	} 

	void gameover(){
		// print gameoover
		Debug.Log ("GAMEOVER");
	}

	void OnCollisionEnter( Collision collision){
// if a gameobject with the tag enemy or enemywepaon colides with the player
		if (collision.gameObject.tag == ("enemy") || collision.gameObject.tag == ("enemyweapon")) { 
		 // call repawn method and set ifrespawn to respawn method return value
			//ifrespawn = respawn();  
			//GameObject.Destroy(gameObject); 
			Application.LoadLevel ("arcadeMenu");
		}
	}


}
