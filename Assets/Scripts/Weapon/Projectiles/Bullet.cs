using UnityEngine;

#pragma warning disable 0649

public class Bullet : Projectile
{
	[SerializeField] private string enemyTagName = "Enemy";

	[Space(15)]
	[SerializeField] private ProjectileData stat;

	public override void OnLaunch() { }
	
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag(enemyTagName)) {
			other.GetComponent<EnemyHP>().TakeDamage(stat.Damage);
			gameObject.SetActive(false);
		}
	}

	public override void OnUpdate() {
        transform.position += transform.right * stat.Speed * Time.deltaTime;
	}
}
