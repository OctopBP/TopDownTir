using UnityEngine;

#pragma warning disable 0649

public class EnemyPlayerHit : MonoBehaviour
{
	[SerializeField] private EnemyOnDeath enemyOnDeath;

	private void OnTriggerEnter2D(Collider2D other) {
		// Если зомби дошёл до игрока, то игрок огребает
		if (other.CompareTag("Player")) {
			enemyOnDeath.OnExplode();
		}
	}
}
