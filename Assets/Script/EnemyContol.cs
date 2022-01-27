using UnityEngine;
using System.Collections;

public class EnemyContol : MonoBehaviour {
	[SerializeField]
	private GameObject[] enemys;
	private int count;         //判斷目前角色

	[SerializeField]
	private GameManager gm;

	void Start()
	{
		InvokeRepeating ("ChoseEnemy", 0, 3);
	}

	void ChoseEnemy()
	{
		if (GameManager.playing == 0)
			return;

		int x = Random.Range (0, 3);  //幾秒後開始執行移動
		Invoke ("EnemyMove", x);

		if (count + 1 < enemys.Length) {
			count++;
		} else {
			count = 0;
		}
	}

	void EnemyMove()
	{
		int x = Random.Range (0, 25);
		while (gm.movePointUse [x])
		{
			x = Random.Range (0, 25);
		}

		Vector3 temp = gm.wayPoints [x].transform.position;
		temp.y = 0.4f;
		enemys [count].transform.position = temp;
		enemys [count].GetComponent<Animator> ().SetTrigger ("Move");
	}

}
