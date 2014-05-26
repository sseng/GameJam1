using UnityEngine;
using System.Collections;

public class CollisionDetectionScript : MonoBehaviour {
	GlobalManager myManager;
	// Use this for initialization
	void Start () {
		myManager = GlobalManager.GetInstance();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/*
	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Player")
		{
			myManager.playerTakeDamage();
		}
    }
	*/
	void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
		{
			myManager.playerTakeDamage();
		}
    }
}
