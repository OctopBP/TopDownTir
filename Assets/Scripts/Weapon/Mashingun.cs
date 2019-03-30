using System.Collections;
using UnityEngine;

public class Mashingun: WeaponBehavior
{
	public override void Shot() {
		StartCoroutine(BurstShot());
	}
	
	private IEnumerator BurstShot() {
		var shotDelay = .1f;

		// Создаём пули с промежутком в shotDelay
		for (int i = 0; i < weaponData.ProjectilesPerShot; i++) {
			SetupProjectile(transform.position, transform.rotation);
			yield return new WaitForSeconds(shotDelay);
		}
	}
}
