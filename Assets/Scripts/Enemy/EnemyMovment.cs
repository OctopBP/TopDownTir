using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
	[SerializeField] private float speed = 5;

    private void Update() {
		// Движение
        transform.position -= transform.right * speed * Time.deltaTime;

		// Поворот
		var cameraPos = Camera.main.transform.position.When(z: 0);
		var direction = transform.position - cameraPos;
		var angle = direction.AngleXY();

		// Разворачиваем маркер
		transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
