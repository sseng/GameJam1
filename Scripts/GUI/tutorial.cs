using UnityEngine;
using System.Collections;

public class tutorial : MonoBehaviour {
	public GUIStyle style;	
	public string[] displayText;
	public float topLeftX = 0;
	public float topLeftY = 0;
	public float sizeX = 200;
	public float sizeY = 20;
	
	private bool tutorialEnabled = false;
	private bool tutorialButton = true;
	private int i = 0;
	
	
	// Use this for initialization
	void Start () {				
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetMouseButtonDown(0) && tutorialEnabled == true)
			if (i < displayText.Length - 1)					
				i++;
			else
				tutorialEnabled = false;
	}
	
	void OnGUI(){				
		//guiText.enabled = tutorialEnabled;
		if(tutorialButton){
			if(GUI.Button(new Rect(10, 10, 70, 20), "tutorial")){
				tutorialEnabled  = true; i = 0;
			}	
		}
		
		if(tutorialEnabled){
			GUI.Label(new Rect(Screen.width/3 + topLeftX, Screen.height/3 + topLeftY, sizeX, sizeY), displayText[i], style);
		}
	}
}
