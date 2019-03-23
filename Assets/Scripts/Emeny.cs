using UnityEngine;

public class Emeny : MonoBehaviour
{
	[SerializeField] private GameObject marker;
	[SerializeField] private GameObject scorePrefab;

	[Header("Расстояния маркера от игрока")]
	[SerializeField] private float markerOffset = 2;

    private void Update() {
		// Получаем направление
		var cameraPos = Camera.main.transform.position;
		cameraPos.z = 0;

		var direction = transform.position - cameraPos;

		// Получаем размеры экрана
		var vertExtent = Camera.main.orthographicSize;
		var horzExtent = vertExtent * Screen.width / Screen.height;

		// Если цель за границей экрана, показываем маркер нарправления
		if (Mathf.Abs(direction.x) > horzExtent || Mathf.Abs(direction.y) > vertExtent) {
			marker.SetActive(true);

			// Получаем угол
			var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

			// Разворачиваем маркер
			marker.transform.eulerAngles = new Vector3(0, 0, angle);

			// Позицианируем маркер
			var markerPos = cameraPos;
			markerPos.z = 0;
			marker.transform.position = markerPos + marker.transform.right * markerOffset;
		}
		else {
			marker.SetActive(false);
		}
    }

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Bullet") {
			// Добавляем одно очко
			GameManager.Instance.AddScore();

			// Создаём текст "+1"
			Instantiate(scorePrefab, transform.position, Quaternion.identity);

			// Уничтожаем мишень
			Destroy(gameObject);
		}
	}
}
