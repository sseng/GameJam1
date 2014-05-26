using UnityEngine;
using System.Collections;

public class controls : MonoBehaviour {
	
	public float moveSpeed = 6;
	public float jumpSpeed = 8;	
	public float gravity = 20;
	public float sprintTime = 2;
	bool isFlying = false;
	
	private float _moveSpeed = 6;
	private float _jumpSpeed = 8;	
	private float _gravity = 20;
	private float sprintTimer;	
	private Vector3 moveDirection = Vector3.zero;	
	private CharacterController controller;
	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update (){			
		movement();
		sprint();
		fly();
	}
	
	public void movement()
	{				
		if(controller.isGrounded && isFlying == false)
		{
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= moveSpeed;
			
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
		}
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
	
	
	public void sprint()
	{
		float walkSpeed = _moveSpeed;
		float sprintSpeed = _moveSpeed * 3;
		sprintTimer -= Time.deltaTime;
		
		if(Input.GetKeyDown("f")){			
			sprintTimer = sprintTime;
		}		
		if(sprintTimer > 0){
			moveSpeed = sprintSpeed;
		}
		else{
			moveSpeed = walkSpeed;
		}
	}
	
	public void fly()
	{
		float flyGravity = _gravity/3;
		
		if(Input.GetKeyDown("g")){
			isFlying = !isFlying;
			Debug.Log(isFlying);
		}
		if(isFlying){
			gravity = flyGravity;
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= moveSpeed;
			
			if (Input.GetButton("Jump"))
				moveDirection.y = jumpSpeed;
		}
		else{
			gravity = _gravity;
		}
	}
}
