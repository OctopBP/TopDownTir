public class Rifle: WeaponBehavior
{
	public override void Shot() {
		SetupProjectile(transform.position, transform.rotation);
	}
}
