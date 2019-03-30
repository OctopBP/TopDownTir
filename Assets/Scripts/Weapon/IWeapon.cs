public interface IWeapon
{
	WeaponData WeaponData { get; }
	float TimeToReload { get; }
	
	void PullTheTrigger();
}