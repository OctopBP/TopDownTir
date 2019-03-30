using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649

public class EnemySpawner : MonoBehaviour
{
	[SerializeField] private GameObject enemyPrefab;

	[Header("Интервал появления новых мишений")]
	[SerializeField] private float interval = 3;

	[Header("Расстояние спавна от игрока")]
	[SerializeField] float minDistanceToSpawn = 0;
	[SerializeField] float maxDistanceToSpawn = 100;

	// Камера всегда привязана к игроку, поэтому берём позицию с неё
	private Camera cam;
	private float time = 0;

	private void Start() {
		cam = Camera.main;
	}

    private void Update() {
		// Спавним врага
		if (time <= 0) {
			SpawnEnemy();
			time = interval;
		}

        time -= Time.deltaTime;
    }

	private void SpawnEnemy() {
		// Пролучаем рандомные коардинаты
		var random = new Random();
		var randomX = random.MirrorRange(minDistanceToSpawn, maxDistanceToSpawn);
		var randomY = random.MirrorRange(minDistanceToSpawn, maxDistanceToSpawn);

		var spawnPosition = cam.transform.position + new Vector3(randomX, randomY, -cam.transform.position.z);

		// Разворачиваем мишень к игроку
		var direction = spawnPosition - cam.transform.position;

		// Получаем угол
		var angle = direction.AngleXY();

		// Создаём новую мишень
		Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(new Vector3(0, 0, angle)));
	}
}
