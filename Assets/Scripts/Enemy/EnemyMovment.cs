using UnityEngine;

#pragma warning disable 0649

public class EnemyMovment : MonoBehaviour
{
	[SerializeField] private EnemyStat enemyStat;

    private void Update() {
		// Движение
        transform.position -= transform.right * enemyStat.MoveSpeed * Time.deltaTime;

		// Поворот
		var cameraPos = Camera.main.transform.position.When(z: 0);
		var direction = transform.position - cameraPos;
		var angle = direction.AngleXY();

		// Разворачиваем маркер
		transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
