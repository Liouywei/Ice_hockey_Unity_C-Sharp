using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountingStart : MonoBehaviour {
	public GameObject Panel;
	private Image ig;
	public float times;
	private float nowtimes;

	public AudioClip AudioPlay;
	private AudioSource aud; //音效來源

	private bool doingEnd = false;

	void Start () {
		nowtimes = times;
		aud = GetComponent<AudioSource>();
		ig = GetComponent<Image> ();
		GameManager.playing = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (nowtimes > 0) {
			nowtimes -= Time.deltaTime;
			ig.fillAmount = nowtimes / times;
		} else {
			if (!doingEnd) {
				doingEnd = true;
				StartCoroutine (ClosePanel ());
			}
		}
	}

	IEnumerator ClosePanel()
	{
		aud.PlayOneShot(AudioPlay);

		yield return new WaitForSeconds (2f);
		GameManager.playing = 1;
		Panel.SetActive (false);
	}
}
