﻿using TMPro;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649

public class PlayerGUI : MonoBehaviour
{
	[Header("GUI")]
	[SerializeField] private TextMeshProUGUI weaponNameText;
	[SerializeField] private TextMeshProUGUI weaponNumberText;
	[SerializeField] private TextMeshProUGUI reloadTimeText;
	[SerializeField] private Image weaponIcon;

	private PlayerShooting playerShooting;

	private void Awake() {
		playerShooting = GetComponent<PlayerShooting>();
		playerShooting.WeaponChanged += UpdateGUI;
	}

	public void UpdateGUI(IWeapon selectedWeapon, int selectedWeaponNumber, int weaponsCount) {
		weaponNameText.text = selectedWeapon.WeaponData.WeaponName;
		weaponNumberText.text = string.Format("{0}/{1}", selectedWeaponNumber + 1, weaponsCount);
		weaponIcon.sprite = selectedWeapon.WeaponData.Icon;
	}

	private void Update() {
		// Reload time gui
		if (playerShooting.selectedWeapon.TimeToReload <= 0) {
			reloadTimeText.text = playerShooting.selectedWeapon.WeaponData.ReloadTime.ToString("0.0");
			reloadTimeText.color = Color.white;
		} else {
			reloadTimeText.text = playerShooting.selectedWeapon.TimeToReload.ToString("0.0");
			reloadTimeText.color = new Color(1, .5f, .5f);
		}
	}
}
