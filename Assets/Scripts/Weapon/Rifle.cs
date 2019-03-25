public class Rifle: WeaponBehavior
{
	public override void Shot() {
		SetupBullet(transform.position, transform.rotation);
	}
}
