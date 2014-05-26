using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public float moveSpeed = 6;
	public GameObject waypoint1;
	public GameObject waypoint2;
	
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
		
		if((targetPos - currentPos).magnitude > 0.1){			
			transform.position = Vector3.MoveTowards(currentPos, new Vector3(targetPos.x, this.transform.position.y, this.transform.position.z), moveSpeed * Time.deltaTime);			
			if((targetPos - currentPos).magnitude < 0.5){
				waypoints();				
			}			
		}	
		/*
		if(moveDirection != Vector3.zero){
				Quaternion rotate = Quaternion.LookRotation(targetPos - transform.position);
				transform.rotation  = Quaternion.Slerp(transform.rotation, rotate, 1);
				transform.LookAt(new Vector3(targetPos.x, 0,0));
				//this.transform.rotation = rotation;
			}
			*/
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
