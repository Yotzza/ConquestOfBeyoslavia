using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab1;
    [SerializeField] GameObject enemyPrefab2;
    [SerializeField] GameObject enemyPrefab3;
    
    [SerializeField] float timeBetweenSpawns = 0.5f;
    float currentTimeBetweenSpawns;

    Transform enemiesParent;

    public static EnemyManager Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        enemiesParent = GameObject.Find("Enemies").transform;
    }

    private void Update()
    {
        currentTimeBetweenSpawns -= Time.deltaTime;
        if (currentTimeBetweenSpawns <= 0)
        {
            SpawnEnemy();
            currentTimeBetweenSpawns = timeBetweenSpawns;
        }
    }

    //random pos za spawnovanje
    Vector2 RandomPosition()
    {
        return new Vector2(Random.Range(-30, 30), Random.Range(-20, 20));
    }

    void SpawnEnemy()
    {
        //Quaternion ignorise rotacije.
        if (CharacterDataClass.CharacterStage<3){
            var e = Instantiate(enemyPrefab1, RandomPosition(), Quaternion.identity);
            e.transform.SetParent(enemiesParent);
        }
        else if(CharacterDataClass.CharacterStage>=3 &&CharacterDataClass.CharacterStage<6){
            var e = Instantiate(enemyPrefab2, RandomPosition(), Quaternion.identity);
            e.transform.SetParent(enemiesParent);
        }
        else{
            var e = Instantiate(enemyPrefab3, RandomPosition(), Quaternion.identity);
            e.transform.SetParent(enemiesParent);
        }
        
    }

    public void DestroyAllEnemies()
    {
        foreach (Transform e in enemiesParent)
            Destroy(e.gameObject);
    }
}
