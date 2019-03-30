using UnityEngine;

public class RifleBullet : Projectile
{
	[SerializeField] private string enemyTagName = "Enemy";
	
	[Space(15)]
	[SerializeField] private float speed = 10;
	[SerializeField] private int damage = 80;

	private bool firstHit = true;

	public override void OnLaunch() { }

	public override void OnUpdate() {
        transform.position += transform.right * speed * Time.deltaTime;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag(enemyTagName)) {
			other.GetComponent<EnemyHP>().TakeDamage(damage);

			if (firstHit)
				firstHit = false;
			else
				gameObject.SetActive(false);
		}
	}

}
