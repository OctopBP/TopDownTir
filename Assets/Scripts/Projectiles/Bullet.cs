using UnityEngine;

public class Bullet : Projectile
{
	[SerializeField] private string enemyTagName = "Enemy";

	[Space(15)]
	[SerializeField] private float speed = 10;
	[SerializeField] private int damage = 50;

	public override void OnLaunch() { }
	
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag(enemyTagName)) {
			other.GetComponent<EnemyHP>().TakeDamage(damage);
			gameObject.SetActive(false);
		}
	}

	public override void OnUpdate() {
        transform.position += transform.right * speed * Time.deltaTime;
	}
}
