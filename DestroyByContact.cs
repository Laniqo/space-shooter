using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;
	public int scoreValue;
	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) {
			gameController = gameControllerObject.GetComponent <GameController> ();
		}
		if (gameController == null) {
			Debug.Log ("Cannot find 'GameController' script");
		} 
	}

	void OnTriggerEnter(Collider other){

		if (other.tag == "Boundary") {
			return;
		}

		//instantiates the explosion for the asteroid when hit by the bolt
		Instantiate(explosion, transform.position, transform.rotation );

		//instantiates the ship's explosion when hitting the asteroid
		if (other.tag == "Player") {
			Instantiate (explosion, other.transform.position, other.transform.rotation);
			gameController.GameOver ();
		}

		gameController.AddScore (scoreValue);

		//destroys the bolt when collision occurs
		Destroy (other.gameObject);

		//destroys the asteroid
		Destroy (gameObject);
	}
}
