using UnityEngine;

#pragma warning disable 0649

public class RifleBullet : Projectile
{
	[SerializeField] private string enemyTagName = "Enemy";
	
	[Space(15)]
	[SerializeField] private ProjectileData stat;

	private bool firstHit;

	public override void OnLaunch() {
		firstHit = true;
	}

	public override void OnUpdate() {
        transform.position += transform.right * stat.Speed * Time.deltaTime;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag(enemyTagName)) {
			other.GetComponent<EnemyHP>().TakeDamage(stat.Damage);

			if (firstHit)
				firstHit = false;
			else
				gameObject.SetActive(false);
		}
	}

}
