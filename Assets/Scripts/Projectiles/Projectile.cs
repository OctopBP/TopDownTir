using UnityEngine;

public abstract class Projectile: MonoBehaviour
{	
	private void Update() {
		OnUpdate();
    }
	
	public abstract void OnLaunch();
	public abstract void OnUpdate();
}