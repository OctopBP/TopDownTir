using UnityEngine;

#pragma warning disable 0649

public class EnemyHP : MonoBehaviour
{
	[SerializeField] private Transform HpBar;
	[SerializeField] private GameObject dmgPrefab;

	[SerializeField] private EnemyStat enemyStat;
	private int hp;

    private void Start() {
        hp = enemyStat.MaxHp;
    }

    private void Update() {
		// Обнуляем углы хп бара, чтобы он не крутился вместе с зомби
        HpBar.eulerAngles = Vector3.zero;
    }

	public void TakeDamage(int dmg) {
		// Получаем урон
		hp -= dmg;

		// Скейлим хп бар
		HpBar.transform.localScale = new Vector3((float) hp / enemyStat.MaxHp, 1, 1);

		// Создаём текст урона
		var dmgText = Instantiate(dmgPrefab, transform.position, Quaternion.identity);
		dmgText.GetComponent<ScoreText>().SetValue(dmg);

		// Если хп < 0, зомби умирает
		if (hp <= 0)
			GetComponent<EnemyOnDeath>().OnDeath();
	}
}
