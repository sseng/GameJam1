using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {
	public Transform target;
    public float damping;
	float xDiff;
	float yDiff;
	public float xLimit;
	public float yLimit;
    void Update () 
	{
		Vector3 xWantedPosition;
		Vector3 yWantedPosition;
		
		xWantedPosition = new Vector3(target.position.x, this.transform.position.y, this.transform.position.z);
		yWantedPosition = new Vector3(this.transform.position.x, target.position.y, this.transform.position.z);
		xDiff = target.position.x - this.transform.position.x;
		yDiff = target.position.y - this.transform.position.y;
		//Debug.Log(yDiff);
		if(xDiff > xLimit || xDiff < -xLimit) 
			transform.position = Vector3.Lerp (transform.position, xWantedPosition, Time.deltaTime * damping);
			
		if(yDiff > yLimit || yDiff < -yLimit)
			transform.position = Vector3.Lerp (transform.position, yWantedPosition, Time.deltaTime * damping);
     }
}
