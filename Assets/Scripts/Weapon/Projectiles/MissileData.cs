using UnityEngine;

[CreateAssetMenu(fileName = "MissileData", menuName = "ProjectileData/MissileData", order = 52)]
public class MissileData : ProjectileData
{	
	[Space(15)]
	[SerializeField] private float turnSpeedMultiplayer = 50;
	public float TurnSpeedMultiplayer => turnSpeedMultiplayer;

	[SerializeField] private float maxDetectionDistance = 10;
	public float MaxDetectionDistance => maxDetectionDistance;

	[SerializeField] private float explRadius = 3;
	public float ExplRadius => explRadius;
}
