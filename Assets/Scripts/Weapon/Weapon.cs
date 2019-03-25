using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon", order = 51)]
public class Weapon : ScriptableObject
{
	[Space(15)]
	[SerializeField] private string weaponName;
	[SerializeField] private Sprite icon;

	[Space(15)]
	[SerializeField] private Bullet bulletPefab;

	[Space(15)]
	[SerializeField] private float reloadTime;

	public enum ShotType {
		Single,	// Одиночный
		Burst,	// Очередь
		Fan		// Веер
	}
	[SerializeField] private ShotType shotType;

	[Tooltip("Для Burst и Fan")]
	[SerializeField] private int bulletsPerShot;

	[Space(15)]
	[Tooltip("Максималное колличество пуль этого оружия в сцене")]
	[SerializeField] private int maxBulletsCount;
	

	public string WeaponName => weaponName;
	public Sprite Icon => icon;
	public Bullet BulletPefab => bulletPefab;
	
	public float ReloadTime => reloadTime;
	public ShotType GetShotType => shotType;

	public int BulletsPerShot => bulletsPerShot;

	public int MaxBulletsCount => maxBulletsCount;
}