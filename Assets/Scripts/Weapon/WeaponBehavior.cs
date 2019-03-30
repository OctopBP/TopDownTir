using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBehavior: MonoBehaviour, IWeapon
{
	[SerializeField] protected WeaponData weaponData;
	public WeaponData WeaponData => weaponData;

	private float timeToReload = 0;
	public float TimeToReload => timeToReload;

	public Queue<Projectile> Projectiles = new Queue<Projectile>();

	private void Start() {
		// Создаём все пули
		for (int i = 0; i < weaponData.MaxProjectilesCount; i++) {
			var projectile = Instantiate(weaponData.ProjectilePefab);
			projectile.gameObject.SetActive(false);
			Projectiles.Enqueue(projectile);
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

	protected void SetupProjectile(Vector3 position, Quaternion rotation) {
		// Берём первую пулю из очереди
		var projectile = Projectiles.Dequeue();

		// Вытсавляем ей позицию и повотор
		projectile.transform.position = position;
		projectile.transform.rotation = rotation;
		projectile.gameObject.SetActive(true);

		// Добавляем её в конец очереди
		Projectiles.Enqueue(projectile);

		projectile.OnLaunch();
	}
}
