using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SearchService;

public class Bullet : MonoBehaviour
{
    public float deleteTime = 5.0f; //削除されるまでの時間
    public GameObject boms; //爆発のエフェクト


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //deleteTime後に消える
        Destroy(gameObject , deleteTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //相手がEnemyタグなら相手を削除
        //相手がEnemyタグならbomsを生成
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy (other.gameObject);
            Instantiate(
                boms,
                other.transform.position,
                Quaternion.identity
                );
        }

        //いずれにしても自分を削除
        Destroy(gameObject);
    }
}
