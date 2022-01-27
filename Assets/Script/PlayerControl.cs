using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	[SerializeField]
	private GameObject[] players;
    private Transform player;
	private int count;         //判斷目前角色
	[SerializeField]
	private GameManager gm;

	[SerializeField]
	private Transform triggerPos;
	private Vector3 triggerRePos;//不使用時移動到的位置
	[SerializeField]
	private GameObject choseAnim;  //Sprite旋轉動畫

	void Start()
	{
		triggerRePos = triggerPos.position;
	}

    void Update()
    {
		if (GameManager.playing == 1) {
			if (Input.GetKeyDown(KeyCode.Q))
			{
				ChangePlayer(count);
			}
		}  
    }

	void ChangePlayer(int id)
    {
		player = players[id].transform;

		if (count + 1 < players.Length)
			count++;
		else
			count = 0;

		WayPointTriggerOn (true);
    }

    public void PlayerMove(int num)
    {
        if (player == null) return;

		if (!gm.movePointUse [num])
		{
			Vector3 temp = gm.wayPoints[num].transform.position;
			temp.y = 0.4f;
			player.position = temp;  //移動完成
			player.GetComponent<Animator>().SetTrigger("Move");

			player = null;
			WayPointTriggerOn (false);
		} 
    }

    void WayPointTriggerOn(bool state)
    {
		if (state) {
			triggerPos.position = player.position;
			choseAnim.SetActive (true);
		} else {
			triggerPos.position = triggerRePos;
			choseAnim.SetActive (false);
		}
			
    }
}
