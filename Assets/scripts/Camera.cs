using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public float speed = 0.8f;

    void Update()
    {
        if (Keyboard.current.cKey.isPressed)
        {
            if (target == null)
                return;

            transform.position = Vector3.MoveTowards(
                transform.position,
                target.position,
                speed * Time.deltaTime
            );
        }
    }
}