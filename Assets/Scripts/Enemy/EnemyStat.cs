using UnityEngine;

#pragma warning disable 0649

[CreateAssetMenu(fileName = "EnemyStat", menuName = "EnemyStat", order = 51)]
public class EnemyStat : ScriptableObject
{
	[Space(15)]
	[SerializeField] private int maxHp;
	public int MaxHp => maxHp;

	[SerializeField] private int moveSpeed;
	public int MoveSpeed => moveSpeed;
}
