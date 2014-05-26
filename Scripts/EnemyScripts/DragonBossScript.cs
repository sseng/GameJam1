using UnityEngine;
using System.Collections;

public class DragonBossScript : MonoBehaviour {
	public Transform targetPos;
	public float step;
	float randSpeedTimer = 3.5f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		randSpeedTimer -= Time.deltaTime;
		if(randSpeedTimer < 0)
		{
			step = Random.Range(0.09f, 0.19f);
			if(step > .11f)
				randSpeedTimer = 2;
			else
				randSpeedTimer = 4;
		}
		
		this.transform.position = Vector3.MoveTowards(transform.position, targetPos.position, step);
		//transform.LookAt(playerPosition.position);
		
		Quaternion rotate = Quaternion.LookRotation(targetPos.position - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime);
		transform.LookAt(new Vector3(targetPos.position.x, targetPos.position.y, 0));
		/*Quaternion rotation = transform.rotation;
		rotation.SetLookRotation(playerPosition.position);
		transform.rotation = rotation;
		*/

	
	}
}
