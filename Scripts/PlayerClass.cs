using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerClass : Unit {
	
	Hashtable controlTable = new Hashtable();
	CharacterControllerBaseClass activeController;
	public List<PickUpClass> pickUpList = new List<PickUpClass>();
	
	public PlayerClass(int health, float moveSpeed)
	{
		this._health = health;
		this._moveSpeed = moveSpeed;
	}
	
	public void addController(CharacterControllerBaseClass c, string name)
	{
		controlTable.Add(name, c);
	}
	
	public void setActiveController(string s)
	{
		activeController = controlTable[s] as CharacterControllerBaseClass;
	}
	
	public void checkInputs()
	{
		activeController.checkInputs(displayObject);	
	}
	
	public void takeDamage()
	{
		_health-=1;
		Debug.Log("OW!!!!");
	}
	
	public void addPickUpItem(PickUpClass p)
	{
		pickUpList.Add(p);
		checkForCompletePickUpList();
	}
	
	void checkForCompletePickUpList()
	{
		if(pickUpList.Count == 4)
		{
			//LOGIC FOR SWAPPING CONTROLL SCHEMES	
		}
	}
}
