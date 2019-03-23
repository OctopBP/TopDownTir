using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
	[SerializeField] private float lifrTime;

	private float time;
	private TextMeshPro text;

    private void Start() {
        text = GetComponent<TextMeshPro>();
		time = lifrTime;

		Destroy(gameObject, lifrTime);
    }

    private void Update() {
        time -= Time.deltaTime;
		
		transform.position += Vector3.up * Time.deltaTime;
		text.alpha = time/ lifrTime;
    }
}
