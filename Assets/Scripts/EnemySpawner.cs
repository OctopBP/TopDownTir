using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private GameObject enemyPrefab;

	[Header("Интервал появления новых мишений")]
	[SerializeField] private float interval = 3;

	[Header("Максимальное расстояние новой мишени от игрока")]
	[SerializeField] float maxDistanceToSpawn = 100;

	// Камера всегда привязана к игроку, поэтому берём позицию с неё
	private Camera cam;
	private float time = 0;

	private void Start() {
		cam = Camera.main;
	}

    private void Update() {
		if (time <= 0) {
			SpawnEnemy();
			time = interval;
		}

        time -= Time.deltaTime;
    }

	private void SpawnEnemy() {
		// Пролучаем рандомные коардинаты в пределах maxDistanceToSpawn
		var randomX = Random.Range(-maxDistanceToSpawn, maxDistanceToSpawn);
		var randomY = Random.Range(-maxDistanceToSpawn, maxDistanceToSpawn);
		var spawnPosition = cam.transform.position + new Vector3(randomX, randomY, -cam.transform.position.z);

		// Разворачиваем мишень к игроку
		var direction = spawnPosition - cam.transform.position;
		var angle = Mathf.Atan(direction.y / direction.x) * Mathf.Rad2Deg;
		angle -= 90 + Mathf.Sign(direction.x) * 90;

		// Создаём новую мишень
		Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(new Vector3(0, 0, angle)));
	}
}
