using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour {
    private float mouRot;
	[SerializeField]
	private Transform[] rotObj;  //要跟著攝影機旋轉的物件
	[SerializeField]
	private Transform camPos;

	void Start()
	{
		ObjRotation ();
	}

    void Update()
    {
		if (GameManager.playing == 1) {
			if (Input.GetKey(KeyCode.Mouse1))
			{
				MouseRotation();
				ObjRotation ();
			}
		}  
    }

    void MouseRotation()
    {
        mouRot = Input.GetAxis("Mouse X");
        transform.RotateAround(transform.position, Vector3.up, mouRot * 2f);
    }

	void ObjRotation()
	{
		Vector3 temp = transform.position;
		temp.y = 0.4f;
		for (int i = 0; i < rotObj.Length; i++)
		{
			rotObj[i].rotation = Quaternion.LookRotation(camPos.position);
		}
	}
}
