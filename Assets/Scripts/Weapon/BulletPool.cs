using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649

public class BulletPool : MonoBehaviour
{
	[SerializeField] private int maxProjectileCount;
	[SerializeField] private Projectile projectilePefab;

	private Queue<Projectile> projectilPool;

	private void Awake() {
		InitPool();
	}

	private void InitPool() {
		projectilPool = new Queue<Projectile>();

		for (int i = 0; i < maxProjectileCount; i++) {
			var projectile = Instantiate(projectilePefab);
			projectile.gameObject.SetActive(false);
			projectilPool.Enqueue(projectile);
		}
	}

	public void SetupProjectile(Vector3 position, Quaternion rotation) {
		// Берём первую пулю из очереди
		var projectile = projectilPool.Dequeue();

		// Вытсавляем ей позицию и повотор
		projectile.transform.position = position;
		projectile.transform.rotation = rotation;
		projectile.gameObject.SetActive(true);

		// Добавляем её в конец очереди
		projectilPool.Enqueue(projectile);
		
		projectile.OnLaunch();
	}
}
