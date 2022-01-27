using UnityEngine;
using System.Collections;

public class ChangeLevel : MonoBehaviour {
	[SerializeField]
	private string name;

	public void NextLevel()
	{
		Application.LoadLevel (name);
	}

	public void NextLevel(string name)
	{
		Application.LoadLevel (name);
	}

	public void QuitGame()
	{
		Application.Quit ();
	}
}
