using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

			// Переводим в углв
			var angle = Mathf.Atan(direction.y / direction.x) * Mathf.Rad2Deg;
			angle += 90 - Mathf.Sign(direction.x) * 90;

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
