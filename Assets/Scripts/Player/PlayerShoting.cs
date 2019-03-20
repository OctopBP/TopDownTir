using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerShoting : MonoBehaviour
{
	[Header("Точка выстрела")]
	[SerializeField] private Transform shotPoint;
	
	[Header("Список оружия")]
	[SerializeField] private List<Weapon> weapons;
	private int selectedWeaponNumber = 0;
	private Weapon selectedWeapon { get { return weapons[selectedWeaponNumber]; } }

	[Header("GUI")]
	[SerializeField] private TextMeshProUGUI weaponNameText;
	[SerializeField] private TextMeshProUGUI reloadTimeText;
	[SerializeField] private Image weaponIcon;

    private void Update() {
		// Выстрел
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
			if (selectedWeapon.timeToReload <= 0) {
				Shot();
			}
		}

		// Кулдаун всех оружий
		foreach (var weapon in weapons) {
			weapon.timeToReload = Mathf.Max(weapon.timeToReload - Time.deltaTime, 0);
		}

		// Выбор оружия
		if (Input.GetKeyDown(KeyCode.Q)) {
			selectedWeaponNumber++;
		}
		if (Input.GetKeyDown(KeyCode.E)) {
			selectedWeaponNumber += weapons.Count - 1;
		}
		selectedWeaponNumber %= weapons.Count;

		// GUI
		weaponNameText.text = selectedWeapon.WeaponName;
		weaponIcon.sprite = selectedWeapon.Icon;
		if (selectedWeapon.timeToReload <= 0) {
			reloadTimeText.text = selectedWeapon.ReloadTime.ToString("0.0");
			reloadTimeText.color = Color.white;
		} else {
			reloadTimeText.text = selectedWeapon.timeToReload.ToString("0.0");
			reloadTimeText.color = new Color(1, .5f, .5f);
		}
    }

	public void Shot() {
		selectedWeapon.timeToReload = selectedWeapon.ReloadTime;

		switch (selectedWeapon.GetShotType) {
			case Weapon.ShotType.Single:
				Instantiate(selectedWeapon.BulletPefab, shotPoint.position, shotPoint.rotation);
			break;

			case Weapon.ShotType.Burst:
				StartCoroutine(BurstShot());
			break;

			case Weapon.ShotType.Fan:
				var bulletCount = 5;
				for (int i = 0; i < bulletCount; i++) {
					var rotation = shotPoint.rotation;
					var angles = rotation.eulerAngles;
					angles.z += 5 * (i - ((float) bulletCount / 2));
					rotation.eulerAngles = angles;
					Instantiate(selectedWeapon.BulletPefab, shotPoint.position, rotation);
				}
			break;
		}
	}

	private IEnumerator BurstShot() {
		var bulletsCount = 3;
		var shotDelay = .1f;

		var t = 0f;
		for (int i = 0; i < bulletsCount; i++) {
			Instantiate(selectedWeapon.BulletPefab, shotPoint.position, shotPoint.rotation);
			t = shotDelay;
			while (t > 0) {
				t -= Time.deltaTime;
				yield return null;
			}
		}
	}
}
