using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

#pragma warning disable 0649

public class GameManager : MonoBehaviour
{
	[SerializeField] private Image bloodScreen;

	[SerializeField] private TextMeshProUGUI counterText;
	private int scores;

	private static GameManager instance;
	public static GameManager Instance => instance;

    private void Start() {
		if (instance == null)
			instance = this;

		scores = 0;
		counterText.text = "0";
    }

	public void AddScore() {
		scores ++;
		counterText.text = scores.ToString();
	}

	public void FineScore() {
		scores -= 5;
		counterText.text = scores.ToString();

		// Мерцание красным
		StartCoroutine(FadeCoroutine());
	}

	public IEnumerator FadeCoroutine() {
		var maxAlpha = .3f;

		var fadeTime = .1f;
		var time = 0f;

		bloodScreen.color = new Color(1, 0, 0, 0);

		while (time < fadeTime) {
			var alpha = maxAlpha * time / fadeTime;
			bloodScreen.color = new Color(1, 0, 0, alpha);

			time += Time.deltaTime;
			yield return null;
		}
		while (time > 0) {
			var alpha = maxAlpha * time / fadeTime;
			bloodScreen.color = new Color(1, 0, 0, alpha);

			time -= Time.deltaTime;
			yield return null;
		}

		bloodScreen.color = new Color(1, 0, 0, 0);
	}
}
