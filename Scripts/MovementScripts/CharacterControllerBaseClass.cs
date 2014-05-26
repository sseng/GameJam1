using UnityEngine;
using System.Collections;

public class CharacterControllerBaseClass {
	
	public CharacterController controller;
	public virtual void checkInputs(GameObject character) {}
	public void setController(GameObject c)
	{
		controller = c.GetComponent<CharacterController>();	
	}
}
