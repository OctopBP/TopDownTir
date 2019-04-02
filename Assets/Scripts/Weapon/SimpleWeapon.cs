public class SimpleWeapon: WeaponBehavior
{
	public override void Shot() {
		bulletPool.SetupProjectile(transform.position, transform.rotation);
	}
}
