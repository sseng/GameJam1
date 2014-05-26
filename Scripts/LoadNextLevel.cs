using UnityEngine;
using System.Collections;

public class LoadNextLevel : MonoBehaviour {
	string NextLevel;
		
	void OnTriggerEnter(Collider hit)
	{
		Application.LoadLevel("boss demo");
	}
}
