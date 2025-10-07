using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class EnemyGenerator : MonoBehaviour
{
    const float Lanewidth = 6.0f;

    public GameObject[] dangerPrefab;

    public float minIntervalTime = 0.1f;
    public float maxIntervalTime = 3.0f;

    float timer;
    float posX;

    GameObject cam;

    public Vector3 defaultPos = new Vector3(0, 10, -60);

    Vector3 diff;
    public float followSpeed = 8;

    int isSky;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = defaultPos;
        cam = Camera.main.gameObject;
        diff = transform.position - cam.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameState != GameState.playing) return;

        timer -= Time.deltaTime; //時間カウントダウン

        if (timer <= 0 )
        {
            DangerCreated();
            maxIntervalTime -= 0.1f;
            maxIntervalTime = Mathf.Clamp(maxIntervalTime, 0.1f, 3.0f);
            timer = Random.Range(minIntervalTime, maxIntervalTime + 1);
        }
    }

    //カメラの追従
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, cam.transform.position + diff, followSpeed * Time.deltaTime);
    }

    //敵車の生成メソッド
    void DangerCreated()
    {
        isSky = Random.Range(0, 2);
        int rand = Random.Range(-2, 3);
        posX = rand * Lanewidth;

        Vector3 v = new Vector3(posX, transform.position.y, transform.position.z);

        if (isSky == 0) v.y = 1;

        Instantiate(dangerPrefab[isSky], v, dangerPrefab[isSky].transform.rotation);
    }
}
