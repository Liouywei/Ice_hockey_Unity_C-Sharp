using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	public Transform camPos;
	public Transform spriteRot;  //Sprite 隨時面向camera

	public Transform particleRot;//特效   隨時面向camera
	public ParticleSystem ps;

	public float moveSpeed;  //移動速度

	public float wallDis;  //距離牆壁多近轉彎
	private RaycastHit rhit;

	private bool isTurn;   //是否有執行轉彎函式

	public AudioClip AudioWall, AudioChacter;
	private AudioSource aud; //音效來源

	void Start()
	{
		aud = GetComponent<AudioSource>();
	}

	void Update()
	{
		if (GameManager.playing == 1) {
			Move();
		}
	}


	void Move()
	{
        if (Physics.Raycast(transform.position, transform.forward, out rhit, wallDis) && GetDistance(rhit.transform) < 2f)
        {
            print(rhit.transform.name + " " + GetDistance(rhit.transform));
            if (rhit.transform.tag == "Wall")
            {
                TurnARound();
                PlaySound(AudioWall);
            }
            else if (rhit.transform.tag == "Player")
            {
                rhit.transform.SendMessage("PlayerHitBall");
                TurnARound();
                PlaySound(AudioChacter);
            }
            else if (rhit.transform.tag == "Enemy")
            {
                rhit.transform.SendMessage("PlayerHitBall");
                TurnARound();
                PlaySound(AudioChacter);
            }
            else
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }


        /*
		if (Physics.Raycast (transform.position, transform.forward, out rhit, wallDis)) {
			if (rhit.transform.tag == "Wall")
			{
				print(rhit.transform.name + " " + GetDistance(rhit.transform));
				if (GetDistance (rhit.transform) < 2f)
				{
					TurnARound ();
					PlaySound (AudioWall);
				}
			}
			if (rhit.transform.tag == "Player")
			{
				print(rhit.transform.name + " " + GetDistance(rhit.transform));
				if (GetDistance (rhit.transform) < 2f)
				{
					rhit.transform.SendMessage ("PlayerHitBall");
					TurnARound ();
					PlaySound (AudioChacter);
				}
			}
			if (rhit.transform.tag == "Enemy")
			{
				print(rhit.transform.name + " " + GetDistance(rhit.transform));
				if (GetDistance (rhit.transform) < 2f)
				{
					rhit.transform.SendMessage ("PlayerHitBall");
					TurnARound ();
					PlaySound (AudioChacter);
				}
			}


		}	
		if (!isTurn) {
			transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
		}
        */
    }

	float GetDistance(Transform x)
	{
		return Vector3.Distance (transform.position, x.position);
	}

	void TurnARound()
	{
		if (isTurn) return;

		isTurn = true;
		ps.Play ();   //碰撞時播放

		int x = Random.Range (0, 2);
		if(x == 0)
			transform.rotation = Quaternion.LookRotation(transform.right);
		
		if(x == 1)
			transform.rotation = Quaternion.LookRotation(-transform.right);

		spriteRot.rotation = Quaternion.LookRotation(camPos.position);
		particleRot.rotation = Quaternion.LookRotation(camPos.position);

		isTurn = false;
	}

	void PlaySound(AudioClip z)
	{
		aud.PlayOneShot(z);
	}
}
