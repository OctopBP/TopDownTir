using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon", order = 51)]
public class Weapon : ScriptableObject
{
	[Space(15)]
	[SerializeField] private string weaponName;
	[SerializeField] private Sprite icon;

	[Space(15)]
	[SerializeField] private GameObject bulletPefab;

	[Space(15)]
	[SerializeField] private float reloadTime;
	[HideInInspector] public float timeToReload;

	public enum ShotType {
		Single,	// Одиночный
		Burst,	// Очередь
		Fan		// Веер
	}
	[SerializeField] private ShotType shotType;

	public string WeaponName {
		get { return weaponName;}
	}
	public Sprite Icon {
		get { return icon;}
	}
	public GameObject BulletPefab {
		get { return bulletPefab;}
	}
	
	public float ReloadTime {
		get { return reloadTime;}
	}
	public ShotType GetShotType {
		get { return shotType;}
	}
}