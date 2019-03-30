using System.Collections.Generic;
using UnityEngine;
using System;

#pragma warning disable 0649

public class PlayerShooting : MonoBehaviour
{
	[Header("Список оружия")]
	[SerializeField] private GameObject weaponsContainer;

	private List<IWeapon> weapons = new List<IWeapon>();
	private int selectedWeaponNumber = 0;
	public IWeapon selectedWeapon { get { return weapons[selectedWeaponNumber]; } }

	public event Action<IWeapon, int, int> WeaponChanged = delegate {};

	private void Start() {
		// Добарляем всё оружие в список
		foreach (Transform weapon in weaponsContainer.transform) {
			weapons.Add(weapon.GetComponent<WeaponBehavior>());
		}
		WeaponChanged(selectedWeapon, selectedWeaponNumber, weapons.Count);
	}

    private void Update() {
		// Выстрел
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
			selectedWeapon.PullTheTrigger();
		}

		// Выбор оружия
		if (Input.GetKeyDown(KeyCode.Q)) {
			selectedWeaponNumber--;
			if (selectedWeaponNumber < 0)
				selectedWeaponNumber = weapons.Count - 1;
			WeaponChanged(selectedWeapon, selectedWeaponNumber, weapons.Count);
		}
		if (Input.GetKeyDown(KeyCode.E)) {
			selectedWeaponNumber++;
			if (selectedWeaponNumber >= weapons.Count)
				selectedWeaponNumber = 0;
			WeaponChanged(selectedWeapon, selectedWeaponNumber, weapons.Count);
		}
    }
}