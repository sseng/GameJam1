using UnityEngine;
using System.Collections;

public class SpawnObstaclesScript : MonoBehaviour {
	public GameObject[] platforms;
	float spitTimer;
	float totalGameTimer;
	int index;
	int randVal;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		spitTimer += Time.deltaTime;
		totalGameTimer += Time.deltaTime;
		if(spitTimer > 1.5f)
		{
			index = Random.Range(0,3);
			randVal = Random.Range(0,1);
			Instantiate(platforms[index],this.transform.position, Random.rotation);
			spitTimer = 0;
		}
	
	}
}
