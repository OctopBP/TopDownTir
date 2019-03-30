using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
	[SerializeField] private float lifeTime = 1;
	[SerializeField] private string template = "+{0}";

	private TextMeshPro text;
	private float time;

    private void Awake() {
        text = GetComponent<TextMeshPro>();
		time = lifeTime;

		Destroy(gameObject, lifeTime);
	}

    private void Update() {
        time -= Time.deltaTime;
		text.alpha = time / lifeTime;
		
		transform.position += Vector3.up * Time.deltaTime;
    }
	
	public void SetValue(int score) {
		text.text = string.Format(template, score);
	}
}
