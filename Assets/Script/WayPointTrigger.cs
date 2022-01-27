using UnityEngine;
using System.Collections;

public class WayPointTrigger : MonoBehaviour {
	[SerializeField]
	private GameObject waypoint;
	[SerializeField]
	private GameManager gm;

	void OnTriggerEnter(Collider hit)
	{
		if (hit.tag == "Player" || hit.tag == "Enemy" || hit.tag == "Ball")
		{
			gm.WayPointStateUpdate (int.Parse(gameObject.name));
			waypoint.SetActive (false);
		}
	}

	void OnTriggerExit(Collider hit)
	{
		if (hit.tag == "Player" || hit.tag == "Enemy" || hit.tag == "Ball")
		{
			gm.WayPointStateUpdate (int.Parse(gameObject.name));
			waypoint.SetActive (true);
		}
	}
}
