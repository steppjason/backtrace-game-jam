using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

	[SerializeField] AudioSource track01;
	[SerializeField] AudioSource track02;

	bool isDefaultTrack = true;

	public void SwapTrack(AudioClip newClip, float volume) {
		StopAllCoroutines();
		StartCoroutine(FadeTracks(newClip, volume));
		isDefaultTrack = !isDefaultTrack;
	}

	IEnumerator FadeTracks(AudioClip newClip, float volume) {

		float timeToFade = 0.5f;
		float timeElapsed = 0f;

		if (isDefaultTrack) {
			track02.clip = newClip;
			track02.Play();
			while (timeElapsed < timeToFade) {
				track02.volume = Mathf.Lerp(0, volume, timeElapsed / timeToFade);
				track01.volume = Mathf.Lerp(track01.volume, 0, timeElapsed / timeToFade);
				timeElapsed += Time.deltaTime;
				yield return null;
			}
			track01.Stop();
		} else {
			track01.clip = newClip;
			track01.Play();
			while (timeElapsed < timeToFade) {
				track01.volume = Mathf.Lerp(0, volume, timeElapsed / timeToFade);
				track02.volume = Mathf.Lerp(track02.volume, 0, timeElapsed / timeToFade);
				timeElapsed += Time.deltaTime;
				yield return null;
			}
			track02.Stop();
		}

	}

}
