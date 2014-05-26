using UnityEngine;
using System.Collections;

public class Unit {

	public int _health;
	public float _moveSpeed;
	public GameObject displayObject;
	
	public int getHealth()
	{
		return _health;
	}
	public float getMoveSpeed()
	{
		return _moveSpeed;
	}
	
	public void setHealth(int health)
	{
		this._health = health;
	}
	
	public void setMoveSpeed(float moveSpeed)
	{
		this._moveSpeed = moveSpeed;
	}
	public void setDisplayObject(GameObject d)
	{
		displayObject = d;
	}
}
