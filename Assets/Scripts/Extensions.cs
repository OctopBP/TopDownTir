using UnityEngine;

public static class Extensions
{
	public static Vector3 With(this Vector3 original, float? x = null, float? y = null, float? z = null) {
		var newX = x.HasValue ? original.x + x.Value : original.x;
		var newY = y.HasValue ? original.y + y.Value : original.y;
		var newZ = z.HasValue ? original.z + z.Value : original.z;
		return new Vector3(newX, newY, newZ);
	}

	public static Vector3 When(this Vector3 original, float? x = null, float? y = null, float? z = null) {
		var newX = x.HasValue ? x.Value : original.x;
		var newY = y.HasValue ? y.Value : original.y;
		var newZ = z.HasValue ? z.Value : original.z;
		return new Vector3(newX, newY, newZ);
	}

	public static Vector3 DirectionTo(this Transform transform, Vector3 destination) {
		return Vector3.Normalize(destination - transform.position);
	}

	public static float AngleXY(this Vector3 direction, bool inRad = true) {
		return Mathf.Atan2(direction.y, direction.x) * (inRad ? Mathf.Rad2Deg : 1);
	}

	public static int Sign(this Random ramdom) {
		return Random.Range(0, 2) * 2 - 1;
	}

	public static float MirrorRange(this Random ramdom, float min, float max) {
		return Random.Range(min, max) * ramdom.Sign();
	}
}