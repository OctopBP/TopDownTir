using UnityEngine;

#pragma warning disable 0649

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon", order = 51)]
public class WeaponData : ScriptableObject
{
	[Space(15)]
	[SerializeField] private string weaponName;
	public string WeaponName => weaponName;

	[SerializeField] private Sprite icon;
	public Sprite Icon => icon;

	[Space(15)]
	[SerializeField] private float reloadTime;
	public float ReloadTime => reloadTime;

	public enum ShotType {
		Single,	// Одиночный
		Burst,	// Очередь
		Fan		// Веер
	}
	[SerializeField] private ShotType shotType;
	public ShotType GetShotType => shotType;

	[Tooltip("Для Burst и Fan")]
	[SerializeField] private int projectilesPerShot;
	public int ProjectilesPerShot => projectilesPerShot;
}