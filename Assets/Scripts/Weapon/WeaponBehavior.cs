using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBehavior: MonoBehaviour
{
	[SerializeField] protected Weapon weaponData;
	public Weapon WeaponData => weaponData;

	private float timeToReload = 0;
	public float TimeToReload => timeToReload;

	public Queue<Bullet> Bullets = new Queue<Bullet>();

	private void Start() {
		// Создаём все пули
		for (int i = 0; i < weaponData.MaxBulletsCount; i++) {
			var bullet = Instantiate(weaponData.BulletPefab);
			bullet.gameObject.SetActive(false);
			Bullets.Enqueue(bullet);
		}

		timeToReload = 0;
	}

	private void Update() {
		timeToReload = Mathf.Max(timeToReload - Time.deltaTime, 0);
	}

	public void PullTheTrigger() {
		if (timeToReload > 0)
			return;

		timeToReload = weaponData.ReloadTime;
		Shot();
	}

	public abstract void Shot();

	protected void SetupBullet(Vector3 position, Quaternion rotation) {
		// Берём первую пулю из очереди
		var bullet = Bullets.Dequeue();

		// Вытсавляем ей позицию и повотор
		bullet.transform.position = position;
		bullet.transform.rotation = rotation;
		bullet.gameObject.SetActive(true);

		// Добавляем её в конец очереди
		Bullets.Enqueue(bullet);
	}
}
