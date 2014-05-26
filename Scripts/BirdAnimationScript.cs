using UnityEngine;
using System.Collections;

public class BirdAnimationScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S)&& !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D))
		{
			animation.Blend("Idle");
		}
		else
		{
			animation.Blend("Forward");	
		}
	
	}
}
