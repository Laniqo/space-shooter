using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {


	//this is called when the other collider(shot) has stopped touching the boundary collider
	// the shot is then destroyed
	void OnTriggerExit(Collider other){
		Destroy (other.gameObject);
	}
		

}
