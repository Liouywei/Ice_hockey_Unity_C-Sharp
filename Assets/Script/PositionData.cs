using UnityEngine;
using System.Collections;

public class PositionData : MonoBehaviour {
    public int id;
	private SpriteRenderer sr;

	void Start()
	{
		sr = GetComponent<SpriteRenderer> ();
	}

    void OnMouseDown()
    {
		if(sr.enabled)
        	Camera.main.SendMessage("PlayerMove", id);
    }

	void OnTriggerEnter(Collider hit)
	{
		if (hit.tag == "CheckLine") {
			sr.enabled = true;
		}
	}

	void OnTriggerExit(Collider hit)
	{
		if (hit.tag == "CheckLine") {
			sr.enabled = false;
		}
	}

	void OnDisable()
	{
		sr.enabled = false;
	}
}
