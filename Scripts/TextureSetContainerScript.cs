using UnityEngine;
using System.Collections;

public class TextureSetContainerScript : MonoBehaviour{

	public Texture2D[] sets;
	int index= 0;
	
	public void increaseTerrorLevel()
	{
		index++;
		this.gameObject.renderer.material.SetTexture("_MainTex", sets[index]);
	}
}
