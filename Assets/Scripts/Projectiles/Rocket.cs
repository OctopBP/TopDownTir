using UnityEngine;

#pragma warning disable 0649

public class Rocket : Projectile
{
	[SerializeField] private string enemyTagName = "Enemy";

	[Space(15)]
	[SerializeField] private float speed = 5;
	[SerializeField] private float turnSpeed = 50;
	[SerializeField] private float turnSpeedMultiplayer = 50;

	[SerializeField] private int damage = 150;

	[SerializeField] private float maxDetectionDistance = 10;

	[Space(15)]
	[SerializeField] private GameObject explPrefab;
	[SerializeField] private float explRadius = 3;

	private Transform target;

	public override void OnLaunch() {
		GetTarget();
	}

	private void GetTarget() {
		// Получаем все таргеты в радиусе обнаружения
		var colliders = Physics2D.OverlapCircleAll(transform.position, maxDetectionDistance);

		// Находим ближайшую мишень
		var minDistanse = Mathf.Infinity;
		foreach (var collider in colliders) {
			if (collider.CompareTag(enemyTagName)) {
				var distance = Vector3.Distance(transform.position, collider.transform.position);
				if (minDistanse > distance) {
					target = collider.transform;
					minDistanse = distance;
				}
			}
		}
	}
	
	public override void OnUpdate() {
        transform.position += transform.right * speed * Time.deltaTime;

		// Поворачиваем к цели
		if (target != null) {
   			var relativePoint = transform.InverseTransformPoint(target.position);
			var isLeft = relativePoint.y > 0;

			var eulers = Vector3.forward * Time.deltaTime * turnSpeed * (isLeft ? 1 : -1);
			transform.Rotate(eulers);
		}

		// Увеличиваем скорость вращения, чтобы избежать бесконечных кругов
		turnSpeed += Time.deltaTime * turnSpeedMultiplayer;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag(enemyTagName)) {
			gameObject.SetActive(false);

			// Создаём взрыв
			var expl = Instantiate(explPrefab, transform.position, Quaternion.identity);
			Destroy(expl, 3);

			// Наносим урон всем врагам в радиусе взрыва
			var col = Physics2D.OverlapCircleAll(transform.position, explRadius);
			foreach (var c in col) {
				if (c.CompareTag(enemyTagName)) {
					c.GetComponent<EnemyHP>().TakeDamage(damage);
				}
			}
		}
	}
}