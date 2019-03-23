using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private float speed = 10;
	[SerializeField] private float lifeTime = 2;
	
	private void Start() {
		Destroy(this.gameObject, lifeTime);
	}

    private void Update() {
        transform.position += transform.right * speed * Time.deltaTime;
    }
}
