using UnityEngine;

#pragma warning disable 0649

public class Missile : Projectile
{
	[SerializeField] private string enemyTagName = "Enemy";

	[Space(15)]
	[SerializeField] private MissileData stat;
	[SerializeField] private float turnSpeed = 50;

	[Space(15)]
	[SerializeField] private GameObject explPrefab;

	private Transform target;

	public override void OnLaunch() {
		GetTarget();
	}

	private void GetTarget() {
		// Получаем все таргеты в радиусе обнаружения
		var colliders = Physics2D.OverlapCircleAll(transform.position, stat.MaxDetectionDistance);

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
        transform.position += transform.right * stat.Speed * Time.deltaTime;

		// Поворачиваем к цели
		if (target != null) {
   			var relativePoint = transform.InverseTransformPoint(target.position);
			var isLeft = relativePoint.y > 0;

			var eulers = Vector3.forward * Time.deltaTime * turnSpeed * (isLeft ? 1 : -1);
			transform.Rotate(eulers);
		}

		// Увеличиваем скорость вращения, чтобы избежать бесконечных кругов
		turnSpeed += Time.deltaTime * stat.TurnSpeedMultiplayer;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag(enemyTagName)) {
			gameObject.SetActive(false);

			// Создаём взрыв
			var expl = Instantiate(explPrefab, transform.position, Quaternion.identity);
			Destroy(expl, 3);

			// Наносим урон всем врагам в радиусе взрыва
			var col = Physics2D.OverlapCircleAll(transform.position, stat.ExplRadius);
			foreach (var c in col) {
				if (c.CompareTag(enemyTagName)) {
					c.GetComponent<EnemyHP>().TakeDamage(stat.Damage);
				}
			}
		}
	}
}