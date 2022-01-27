using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallNet : MonoBehaviour {
	public BallControl bc;

	public AudioClip Audiogoal;
	private AudioSource aud; //音效來源

	public bool playMode; //false 單人遊戲 true 雙人遊戲
	public GameObject signleTxt;

	public bool red_blue;   //false = 紅隊 true = 藍隊
	public GameObject muiltTxt1;
	public GameObject muiltTxt2;

	void Start()
	{
		aud = GetComponent<AudioSource>();
	}

	void OnTriggerEnter(Collider hit)
	{
		if (hit.tag == "Ball") {
			if (!playMode) {
				StartCoroutine ("GetPoint1");
			} else {
				StartCoroutine ("GetPoint2");
			}

			hit.gameObject.SetActive (false);
			aud.PlayOneShot(Audiogoal);
			bc.PlayBall ();
		}
	}

	IEnumerator GetPoint1()
	{
		signleTxt.SetActive (true);
		yield return new WaitForSeconds (2f);
		signleTxt.SetActive (false);
	}

	IEnumerator GetPoint2()
	{
		if (!red_blue) {
			muiltTxt1.SetActive (true);
		} else {
			muiltTxt2.SetActive (true);
		}
		yield return new WaitForSeconds (2f);
		if (!red_blue) {
			muiltTxt1.SetActive (false);
		} else {
			muiltTxt2.SetActive (false);
		}
	}
}
