using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLockAt : MonoBehaviour
{
	[SerializeField] private GameObject target;

    private void Update() {
        var targetPos = target.transform.position;
		targetPos.z = transform.position.z;
		transform.position = targetPos;
    }
}
