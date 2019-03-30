using UnityEngine;

public class Shotgun: WeaponBehavior
{
	public override void Shot() {
		// Создаём веер пуль
		for (int i = 0; i < weaponData.ProjectilesPerShot; i++) {
			var deltaAngle = 5f;
			var angleZ = deltaAngle * ((float) i - (((float) weaponData.ProjectilesPerShot - 1) / 2f));
			var projectileRotation = transform.eulerAngles.With(z: angleZ);

			SetupProjectile(transform.position, Quaternion.Euler(projectileRotation));
		}
	}
}
