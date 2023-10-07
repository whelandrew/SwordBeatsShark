using UnityEngine;

public class GameboardController : MonoBehaviour
{
    private Level curLevel = new Level();

    public GameObject spawnPointCache;
    public GameObject objectPrefab;
    
    void Start()
    {
        SetSpawnPoints(curLevel.phases[0].enemies);
    }

    void Update()
    {
    }

    private void SetSpawnPoints(Entity[] enemies)
    {
        //get enemies and place them
        int maxSpawns = curLevel.phases[0].enemies.Length;
        int lastSpawnPoint = -1;
        int i = 0;
        Transform[] allSpawnPoints = spawnPointCache.GetComponentsInChildren<Transform>();
        while (i < maxSpawns)
        {
            int spawnPoint = Random.Range(0, spawnPointCache.transform.childCount) ;
            if (spawnPoint != lastSpawnPoint)
            {
                GameObject newEnemey = Instantiate(objectPrefab);
                newEnemey.transform.parent = transform;
                newEnemey.transform.position = allSpawnPoints[i].transform.position;
                
                i++;
            }
        }
    }

    public void SetCurLevel(Level newLevel)
    {
        curLevel = newLevel;
    }
    public Level GetCurrentLevel()
    {
        return curLevel;
    }
}
