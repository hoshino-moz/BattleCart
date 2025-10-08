using UnityEngine;

public class Bom : MonoBehaviour
{
    public float deleteTime = 3.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //生成されて数秒後に削除
        Destroy(gameObject , deleteTime);
    }

   
}
