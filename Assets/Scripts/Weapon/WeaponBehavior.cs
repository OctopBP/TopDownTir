using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BulletPool))]
public abstract class WeaponBehavior: MonoBehaviour, IWeapon
{
	[SerializeField] protected WeaponData weaponData;
	public WeaponData WeaponData => weaponData;

	private float timeToReload = 0;
	public float TimeToReload => timeToReload;

	protected BulletPool bulletPool;

	private void Awake() {
		bulletPool = GetComponent<BulletPool>();
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
}
