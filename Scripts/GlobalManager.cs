using UnityEngine;
using System.Collections;

public class GlobalManager : MonoBehaviour {
	public bool flyOn;
	public bool controlsPaused;
	//static instance of globalManager
	static GlobalManager instance = null;
	//Player GameObject && Player Class
	public GameObject playerObj;
	PlayerClass player = new PlayerClass(3, 6);
	//camera obj
	public GameObject camera;
	GameObject[] enemyObjects;
	EnemyClass[] enemyClasses;
	
	bool pickUpObjectState_1 = false;
	bool pickUpObjectState_2 = false;
	float zoomInTimer = 0;
	bool damageTimerOn = false;
	float damageTimer = 0;
	
	//HP Icon/HUD Variables	
	public Texture2D healthTex;	
	public float hpIconWidth;
	public float hpIconHeight;	
	public float hpIconX;
	public float hpIconY;
	private int iconAmount;
	
	//Tutorial variables
	public GUIStyle tutorialStyle;	
	public string[] tutorialText;
	public float tutorialTopLeftX = 0;
	public float tutorialTopLeftY = 0;
	public float tutorialSizeX = 200;
	public float tutorialSizeY = 20;
	
	private bool tutorialEnabled = false;
	private bool tutorialButton = true;
	private int tutorialPage = 0;
	
 
	Rect healthRect;
	// Use this for initialization
	void Start () {
		enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
		enemyClasses = new EnemyClass[enemyObjects.Length];
		for (int i = 0; i < enemyClasses.Length;i++)
		{
			enemyClasses[i] = new EnemyClass(1,1);
			enemyClasses[i].setDisplayObject(enemyObjects[i]);
		}
		//set the player's display object
		player.setDisplayObject(playerObj);
		//setUpCharacterControlSchemes and default controls
		CharacterControllerBaseClass nForm = new NormalForm();
		nForm.setController(playerObj);
		player.addController(nForm, "normalForm");
		CharacterControllerBaseClass fForm = new FlyControls();
		fForm.setController(playerObj);
			player.addController(fForm, "flyForm");
		if(flyOn)
			player.setActiveController("flyForm");
		else	
			player.setActiveController("normalForm");
		
	}
	
	// Update is called once per frame
	void Update () {
		//check for character movement inputs
		player.checkInputs();
		evalutatePickUpTransformStates();
		evaluateDamageStates();
		
		if(player.pickUpList.Count == 3)
		{
			player.setActiveController("flyForm");
		}
		
	}
	
	//GUI CONTROLS
	void OnGUI()
	{
		int xpos = 100;
		foreach(PickUpClass p in player.pickUpList)
		{
			GUI.Label(new Rect(xpos,Screen.height - 100,p._displayImage.width/3, p._displayImage.height/3), p._displayImage);
			xpos+= p._displayImage.width/3;
		}
		//hp icons interface
		for(iconAmount = 1; iconAmount < player._health+1; iconAmount++){
			GUI.Label(new Rect(hpIconX*iconAmount + hpIconWidth*iconAmount, hpIconY, hpIconWidth, hpIconHeight), healthTex);
		}
		//tutorial interface
		if(tutorialEnabled){
			GUI.Label(new Rect(Screen.width/3 + tutorialTopLeftX, Screen.height/3 + tutorialTopLeftY, tutorialSizeX, tutorialSizeY), tutorialText[tutorialPage], tutorialStyle);
		}
	}
	
	void playTutorial(){
		if(Input.GetMouseButtonDown(0) && tutorialEnabled == true)
			if (tutorialPage < tutorialText.Length - 1)					
				tutorialPage++;
			else
				tutorialEnabled = false;		
	}
	void showTutorial(){
		tutorialEnabled = true;
	}
	
	public void playerTakeDamage()
	{
		if(!damageTimerOn)
		{
			player.takeDamage();
			damageTimerOn = true;
			if(player._health <= 0)
			{
				//player.displayObject
			}
		}
	}
	
	public void playerPickUpObject(PickUpClass p)
	{
		player.addPickUpItem(p);
		pickUpObjectState_1 = true;
		controlsPaused = true;
		//add pickup effect, sound effects here
		
	}
	
	public static GlobalManager GetInstance()
	{
		if(instance == null)
		{
			instance = FindObjectOfType(typeof (GlobalManager)) as GlobalManager;	
		}
		return instance;
	}
	
	void evalutatePickUpTransformStates()
	{
		if(pickUpObjectState_1)
		{
			pickupTransformState_1();
		}
		else if(pickUpObjectState_2)
		{
			zoomInTimer += Time.deltaTime;
			if(zoomInTimer > 1.5f)
				pickupTransformState_2();	
		}
	}
	
	void evaluateDamageStates()
	{
		if(damageTimerOn)
		{
			damageTimer+= Time.deltaTime;
			if(damageTimer > 2)
			{
				damageTimer = 0;
				damageTimerOn = false;
			}
		}
	}
	
	void pickupTransformState_1()
	{
		float target= -5.5f;
		camera.transform.position = Vector3.MoveTowards(camera.transform.position, new Vector3(camera.transform.position.x, camera.transform.position.y,target), Time.deltaTime*7);
		if(camera.transform.position.z == target)
		{
			pickUpObjectState_1 = false;
			pickUpObjectState_2 = true;
			this.gameObject.BroadcastMessage("increaseTerrorLevel");
		}
	}
	void pickupTransformState_2()
	{
		float target = -15;
		camera.transform.position = Vector3.MoveTowards(camera.transform.position, new Vector3(camera.transform.position.x, camera.transform.position.y, target), Time.deltaTime*5);
		if(camera.transform.position.z == target)
		{
			pickUpObjectState_2 = false;
			controlsPaused = false;
			zoomInTimer = 0;
		}
	}
}
