using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothSpeed = 0.125f;

    private void FixedUpdate()
    {
        Vector2 desiredPosition = (Vector2)target.position;
        Vector2 smooothedPosition = Vector3.Lerp((Vector2)transform.position, desiredPosition, smoothSpeed);

        transform.position = new Vector3(smooothedPosition.x, smooothedPosition.y, -10);
    }

}
