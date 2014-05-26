using UnityEngine;
using System.Collections;

public class EndLevelScript : MonoBehaviour {
	float displayTimer = 10;
	float endGameTimer = 60;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		displayTimer-= Time.deltaTime;
		endGameTimer -= Time.deltaTime;
		if(displayTimer > 0)
		{
			GUI.Label(new Rect(100, 100, 200,200), "SURVIVE FOR A MINUTE");	
		}
		
		GUI.Label(new Rect(100, Screen.height-100, 200,200), endGameTimer.ToString());
		if(endGameTimer < 0)
		{
			Application.Quit();
		}
	}
}
