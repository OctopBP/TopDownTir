using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[Header("Скорость движения")]
	[SerializeField] private float speed = 10f;

    private void Update() {
		// Перемещение
		Movement();

		// Вращение
		Rotation();
    }

	private void Movement() {
		var moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

		// Чтобы перосонаж двигался по диагонали не быстрее чем вверх-вниз и вправо-влево
		moveDirection = Vector3.ClampMagnitude(moveDirection, 1);

		var movement = moveDirection * speed * Time.deltaTime;
		transform.position += movement;
	}

	private void Rotation() {
		// Получаем направление
 		var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		var direction = transform.DirectionTo(mousePos);
		
		// Получаем угол
		var angle = direction.AngleXY();
		transform.eulerAngles = new Vector3(0, 0, angle);
	}
}