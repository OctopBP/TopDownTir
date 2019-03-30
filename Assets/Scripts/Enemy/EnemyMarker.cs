using UnityEngine;

#pragma warning disable 0649

public class EnemyMarker : MonoBehaviour
{
	[SerializeField] private GameObject marker;

	[Header("Расстояния маркера от игрока")]
	[SerializeField] private float markerOffset = 2;

    private void Update() {
		// Получаем направление
		var cameraPos = Camera.main.transform.position.When(z: 0);
		var direction = transform.position - cameraPos;

		// Получаем размеры экрана
		var vertExtent = Camera.main.orthographicSize;
		var horzExtent = vertExtent * Screen.width / Screen.height;

		// Если цель за границей экрана, показываем маркер нарправления
		if (Mathf.Abs(direction.x) > horzExtent || Mathf.Abs(direction.y) > vertExtent) {
			marker.SetActive(true);

			// Получаем угол
			var angle = direction.AngleXY();

			// Разворачиваем маркер
			marker.transform.eulerAngles = new Vector3(0, 0, angle);

			// Позицианируем маркер
			var markerPos = cameraPos;
			marker.transform.position = markerPos + marker.transform.right * markerOffset;
		}
		else {
			marker.SetActive(false);
		}
    }
}
