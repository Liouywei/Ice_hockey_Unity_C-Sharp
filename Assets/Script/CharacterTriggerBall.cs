using UnityEngine;
using System.Collections;

public class CharacterTriggerBall : MonoBehaviour {
	private Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
	}

	public void PlayerHitBall()
	{
		anim.SetTrigger ("Hit");
	}

}
