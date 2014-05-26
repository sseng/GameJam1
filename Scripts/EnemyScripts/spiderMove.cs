using UnityEngine;
using System.Collections;

public class spiderMove : MonoBehaviour {
	public float moveSpeed = 6;
	public GameObject waypoint1;
	public GameObject waypoint2;
	public GameObject player;
	
	private bool wp1 = false;
	private bool wp2 = true;
	
	private Vector3 targetPos;
	private Vector3 currentPos;	
	private Vector3 moveDirection = Vector3.zero;
	
	// Use this for initialization
	void Start () {	
		waypoints();
	}
	
	// Update is called once per frame
	void Update () {			
		currentPos = transform.position;
		/*
		// chase player. test.
		if((player.transform.position - currentPos).magnitude < 3){
			targetPos = player.transform.position;
		}
		else{
			waypoints();	
		}
		
		// chase player end.*/
		
		if((targetPos - currentPos).magnitude > 0.1){
			moveDirection = new Vector3(targetPos.x, 0, 0);
			
			if(moveDirection != Vector3.zero){
				Quaternion rotation = transform.rotation;
				rotation.SetLookRotation(moveDirection);
				transform.rotation = rotation;
			}
			
			moveDirection *= moveSpeed;
			
			
			if((targetPos - currentPos).magnitude < 0.5){
				waypoints();				
			}
			transform.position = Vector3.MoveTowards(currentPos, new Vector3(targetPos.x, 0,0), moveSpeed * Time.deltaTime);			
		}			
	}
	
	void waypoints(){
		if (wp1 == true){
			targetPos = waypoint1.transform.position;
		}
		if (wp2 == true){
			targetPos = waypoint2.transform.position;
		}		
		wp1 = !wp1;
		wp2 = !wp2;
	}
}
