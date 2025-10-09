using UnityEngine;

public class EnemyController : MonoBehaviour
{
    CharacterController controller;

    Vector3 moveDirection = Vector3.zero;

    public float gravity = 9.81f;

    public float speedZ = -10;
    public float accelerationZ = -8;

    public float deletePosY = -10f; //落ちていったら、、消す
    public bool useGravity; //重力あるなし

    GameObject camera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();

        //空中車
        if (useGravity)
        {
            Destroy(gameObject, 20);
        }
    }

    void Update()
    {
        //ステージ外に落ちたら消滅
        if (transform.position.y <= deletePosY)
        {
            Destroy(gameObject);
            return;
        }

        //徐々に加速しZ方向に常に前進させる
        float accelerationedZ = moveDirection.z + (accelerationZ * Time.deltaTime);
        moveDirection.z = Mathf.Clamp(accelerationZ, speedZ, 0);

        //地面を走るフラグ
        if (useGravity)
        {
            //重力分の力をフレーム追加
            moveDirection.y -= gravity * Time.deltaTime;
        }
        else  //空を飛ぶフラグ
        {
            moveDirection.y = 0;
        }

        //移動実行
        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        controller.Move(globalDirection * Time.deltaTime);

        //移動後接地してたらY方向の速度はリセットする
        if (controller.isGrounded) moveDirection.y = 0;
    }

}
