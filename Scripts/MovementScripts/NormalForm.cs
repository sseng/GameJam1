using UnityEngine;
using System.Collections;

public class NormalForm : CharacterControllerBaseClass {
	
	public float moveSpeed = 6;
	public float jumpSpeed = 8;	
	public float gravity = 20;
	public float sprintTime = 1.5f;
	public float sprintCD = 5;
	bool isFlying = true;
	
	private float _moveSpeed = 6;
	private float _jumpSpeed = 8;	
	private float _gravity = 20;
	private Vector3 moveDirection = Vector3.zero;	
	GlobalManager myManager;
	
	bool characterSprinting = false;
	bool sprintCoolDown = false;
	
	//private CharacterController controller;
	
	
	public NormalForm(){}
	
	public override void checkInputs(GameObject character)
	{
		if(myManager == null)
		{
			myManager = GlobalManager.GetInstance();	
		}
		movement(character);
		sprint(character);
		//Debug.Log("HELLO");
	}
	
	public void movement(GameObject character)
	{			
		if(controller.isGrounded)
		{
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
			moveDirection = character.transform.TransformDirection(moveDirection);
			moveDirection *= moveSpeed;
			
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
		}
		moveDirection.y -= gravity * Time.deltaTime;
		if(myManager.controlsPaused)
			controller.Move(Vector3.zero);
		else
			controller.Move(moveDirection * Time.deltaTime);
	}
	
	
	public void sprint(GameObject character)
	{
		float sprintSpeed = moveSpeed *1.5f;
		float walkSpeed = _moveSpeed;
		
		if(Input.GetKeyDown("q") && !sprintCoolDown){

			characterSprinting = true;
			moveSpeed = sprintSpeed;
		}
		if(characterSprinting)
		{
			sprintTime -= Time.deltaTime;
			if(sprintTime < 0)
			{
				sprintTime = 2;
				moveSpeed = walkSpeed;
				sprintCoolDown = true;
				sprintCD = 5;
				characterSprinting = false;
			}
		}
		
		if(sprintCoolDown)
		{
			sprintCD -= Time.deltaTime;
			if(sprintCD < 0)
			{
				sprintCoolDown = false;	
			}
		}
	}
}
