using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	public AudioClip shootSound;

	private AudioSource source;
	private float volLowRange = .5f;
	private float volHighRange = 1.0f;


	void Awake(){
		source = GetComponent<AudioSource>();

	}


	void Update()
	{


		var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

		transform.Rotate(0, x, 0);
		transform.Translate(0, 0, z);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Fire();
		}
	}


	void Fire()
	{

		Pew ();
		// Create the Bullet from the Bullet Prefab
		var bullet = (GameObject)Instantiate(
			bulletPrefab,
			bulletSpawn.position,
			bulletSpawn.rotation);

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 60;

		// Destroy the bullet after 2 seconds
		Destroy(bullet, 2.0f);        
	}

	void Pew(){

		float vol = Random.Range (volLowRange, volHighRange);
		source.PlayOneShot(shootSound,vol);




	}



}
