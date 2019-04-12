using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<Transform> spawners;
    [SerializeField] int maxAis;
    [SerializeField] LayerMask layer;

    public GameManager Instance;

    int ActiveAIs=0;

    private void Start()
    {
        if (Instance == null)
            Instance = this;

        SpawnAIs();

    }

    void SpawnAIs()
    {
        for (int i = 0; i < maxAis; i++)
        {
            Transform t = spawners[Random.Range(0, spawners.Count)];
            AICharacter aI =  AisPool.Instance.GetBulletAt(t.position, t.rotation);
            aI.OnDeasth += ReadDeath;
            ActiveAIs++;
        }
    }

    public void ReadDeath(AICharacter aI)
    {
        ActiveAIs--;
        aI.OnDeasth -= ReadDeath;
        CheckActiveAIs();
    }

    void CheckActiveAIs()
    {
        if(ActiveAIs==0)
        {
            Invoke( "SpawnAIs",3);
        }
    }

}
