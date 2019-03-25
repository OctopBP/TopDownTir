using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerShooting : MonoBehaviour
{
	[Header("Список оружия")]
	[SerializeField] private GameObject weaponsContainer;

	private List<WeaponBehavior> weapons = new List<WeaponBehavior>();
	private int selectedWeaponNumber = 0;
	public WeaponBehavior selectedWeapon { get { return weapons[selectedWeaponNumber]; } }

	public event Action<WeaponBehavior, int, int> WeaponChanged = delegate {};

	private void Start() {
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