using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileData", menuName = "ProjectileData/ProjectileData", order = 51)]
public class ProjectileData : ScriptableObject
{
	[Space(15)]
	[SerializeField] private int damage = 0;
	public int Damage => damage;

	[SerializeField] private float speed = 0;
	public float Speed => speed;
}
