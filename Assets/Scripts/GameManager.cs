using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI counterText;
	private int scores;

	public static GameManager Instance;

    private void Start() {
		Instance = this;

		scores = 0;
		counterText.text = "0";
    }

	public void AddScore() {
		scores++;
		counterText.text = scores.ToString();
	}
}
