using UnityEngine;
using System.Collections;

public class BallControl : MonoBehaviour {
	public GameObject ball;
	public GameManager gm;

	private Vector3 ballPos;

	void Start()
	{
		ballPos = ball.transform.position;
		PlayBall ();
	}

	//發球
	public void PlayBall()
	{
		Invoke ("ChosePosition", 2);
	}

	void ChosePosition()
	{
		int x = Random.Range (0, 25);
		while (gm.movePointUse [x])
		{
			x = Random.Range (0, 25);
		}

		ballPos.x = gm.wayPoints [x].transform.position.x;
		ballPos.z = gm.wayPoints [x].transform.position.z;
		ball.transform.position = ballPos;
		ball.SetActive (true);
	}

}
