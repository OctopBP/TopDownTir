using UnityEngine;

public abstract class Projectile: MonoBehaviour
{	
	public abstract void OnLaunch();
	public abstract void OnUpdate();
	
	private void Update() {
		OnUpdate();
    }
}