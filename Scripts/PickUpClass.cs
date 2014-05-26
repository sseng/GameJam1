using UnityEngine;
using System.Collections;

public class PickUpClass {

	public int _id;
	public Texture2D _displayImage;
	public GameObject _specialEffect;
	public AudioClip _soundEffect;
	
	public PickUpClass(int id, GameObject specialEffect, AudioClip soundEffect, Texture2D displayImage)
	{
		this._id = id;
		this._specialEffect = specialEffect;
		this._soundEffect = soundEffect;
		this._displayImage = displayImage;
	}
	public int getID()
	{
		return this._id;	
	}
	public GameObject getSpecialEffect()
	{	
		return this._specialEffect;
	}
	public AudioClip getSoundEffect()
	{	
		return this._soundEffect;
	}
	public Texture2D getDisplayImage()
	{
		return this._displayImage;	
	}
}
