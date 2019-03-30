using UnityEngine;

#pragma warning disable 0649

public class EnemyOnDeath : MonoBehaviour
{
	[SerializeField] private GameObject scorePrefab;
	[SerializeField] private GameObject minusScorePrefab;

	public void OnDeath() {
		// Добавляем одно очко
		GameManager.Instance.AddScore();

		// Создаём текст "+1"
		Instantiate(scorePrefab, transform.position, Quaternion.identity);

		// Уничтожаем врага
		Destroy(gameObject);
	}

	public void OnExplode() {
		// Отнимаем 5 очков
		GameManager.Instance.FineScore();

		// Создаём текст "-5"
		Instantiate(minusScorePrefab, transform.position, Quaternion.identity);

		// Уничтожаем врага
		Destroy(gameObject);
	}
}
