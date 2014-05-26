using UnityEngine;
using System.Collections;

public class SelfDestroyScript : MonoBehaviour {
	float timer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		timer+= Time.deltaTime;
		if(timer > 4)
			Destroy(this.gameObject);
	
	}
}
