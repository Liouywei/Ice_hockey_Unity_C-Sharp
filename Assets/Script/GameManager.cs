using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject[] wayPoints = new GameObject[25];
	public bool[] movePointUse = new bool[25];   //wayPoint是否使用中

	public static int playing = 1;  //遊戲狀態 => 1 : 執行  0 : 暫停

	//玩家或AI進入、離開時更新wayPoint的bool狀態 : wayPoint自己呼叫
	public void WayPointStateUpdate(int id)
	{
		movePointUse [id] = !movePointUse [id];
	}

	public void TimeStop()
	{
		playing = 0;
	}

	public void TimeStart()
	{
		playing = 1;
	}
}
