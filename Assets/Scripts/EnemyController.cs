using Unity.Android.Gradle.Manifest;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyController : MonoBehaviour
{
    CharacterController controller;

    Vector3 moveDirection = Vector3.zero;

    public float gravity = 9.81f;

    public float speedZ = -10;
    public float accelerationZ = -8;

    public float deletePosY = -10f;
    public bool useGravity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    void Update()
    {
        if (transform.position.y <= deletePosY)
        {
            Destroy(gameObject);
            return;
        }

        float accelerationedZ = moveDirection.z + (accelerationZ * Time.deltaTime);
        moveDirection.z = Mathf.Clamp(accelerationZ, speedZ, 0);

        if (useGravity)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        else
        {
            moveDirection.y = 0;
        }

        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        controller.Move(globalDirection * Time.deltaTime);

        if (controller.isGrounded) moveDirection.y = 0;
    }

}
