using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;	
}


public class PlayerController : MonoBehaviour {

	public float speed;
	public Boundary boundary;
	public float tilt;

	public GameObject shot;
	public Transform shotSpawn; //shotSpawn.transform.position
	public float fireRate; 

	private float nextFire;

	//code for mouse fire shooting of the ship
	void Update()
	{
		if(Input.GetButton("Fire1") && Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			//as GameObject tells unity what type of object is being instantiated
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation); //as GameObject;
			GetComponent<AudioSource>().Play();
			//a.Play();
		}
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		//moving the player object using user input
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		//declares the rigid body component wrapping the ship for reference of the player GameObject
		Rigidbody rb = GetComponent<Rigidbody>();

		//multiplies the velocity of the sheept, for faster movement during game
		rb.velocity = movement * speed;

		//restrictions for boundaries on the game
		rb.position = new Vector3 (
			Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
		);

		//tilt factor of the ship when it moves left/right
		rb.rotation = Quaternion.Euler (0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}
