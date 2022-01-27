using UnityEngine;
using System.Collections;

public class WallColorScript : MonoBehaviour {

	[SerializeField] private Material[] col;
	[SerializeField] private int count; 
	[SerializeField] private int speed;

	[SerializeField] private Renderer[] wallRender;

	void Start()
	{
		InvokeRepeating("CountAdd", 0, 1);
	}

	void FixedUpdate()
	{
		LerpColor();
	}

	void LerpColor()
	{
		for (int i = 0; i < wallRender.Length; i++)
		{
			wallRender[i].material.Lerp(wallRender[i].material, col[count], speed * Time.deltaTime);
		}
	}

	void CountAdd()
	{
		if (count + 1 < col.Length)
			count++;
		else
			count = 0;
	}
}
