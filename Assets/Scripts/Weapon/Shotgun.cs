public class Shotgun: WeaponBehavior
{
	public override void Shot() {
		// Создаём веер пуль
		for (int i = 0; i < weaponData.BulletsPerShot; i++) {
			var bulletRotation = transform.rotation;
			var angles = bulletRotation.eulerAngles;
			var deltaAngle = 5f;

			angles.z += deltaAngle * ((float) i - (((float) weaponData.BulletsPerShot - 1) / 2f));
			bulletRotation.eulerAngles = angles;

			SetupBullet(transform.position, bulletRotation);
		}
	}
}
