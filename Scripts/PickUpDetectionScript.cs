using UnityEngine;
using System.Collections;

public class PickUpDetectionScript : MonoBehaviour {
	GlobalManager myManager;
	public int _id;
	public Texture2D _displayImage;
	public GameObject _specialEffect;
	public AudioClip _soundEffect;
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
			PickUpClass pick = new PickUpClass(_id,_specialEffect,_soundEffect,_displayImage);
			myManager.playerPickUpObject(pick);
			DestroyObject(this.gameObject);
		}
		
		
    }
    */
	 void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player")
		{
			PickUpClass pick = new PickUpClass(_id,_specialEffect,_soundEffect,_displayImage);
			myManager.playerPickUpObject(pick);
			DestroyObject(this.gameObject);
		}
    }
}
