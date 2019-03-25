using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI counterText;
	private int scores;

	private static GameManager Instance;
	public static GameManager instance => Instance;

    private void Start() {
		if (Instance == null)
			Instance = this;

		scores = 0;
		counterText.text = "0";
    }

	public void AddScore() {
		scores++;
		counterText.text = scores.ToString();
	}
}
