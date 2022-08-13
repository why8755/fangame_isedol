using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class SpawningPool : MonoBehaviour
{
    //관련기획 부재로 간략하게 작성
    public GameObject theEnemy;
    public int EnenmySpawnCount;
    public int xPos;
    public int yPos;

    /* [SerializeField]
     int _monsterCount = 0; // 현재 Enemy 수
     int _reserveCount = 0; // 코루틴을 생성할 때 현재 예약된 코루틴이 몇개인지 판단하기 위해
     [SerializeField]
     int _keepMonsterCount = 5;  // 필드에 최대 Enemy 수
     [SerializeField]
     Vector3 _spawnPos; // Spawn 위치
     [SerializeField]
     float _spawnRadius = 15.0f; // Spawn 범위
     [SerializeField]
     float _spawnTime = 5.0f; // 간격*/

    //public void AddMonsterCount(int value) { _monsterCount += value; }
    //public void SetKeepMonsterCount(int count) { _keepMonsterCount = count; }

    void Start()
    {
        
    }

    void Update()
    {
        // 지속적인 스폰일 경우 사용
        /*while (_reserveCount + _monsterCount < _keepMonsterCount)
        // 현재 몬스터의 수와 예약된 코루틴의 수가 _keepMonsterCount보다 적다면 코루틴 실행
        {
            StartCoroutine("ReserveSpawn");
        }*/
    }

    private void OntriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player(Gosegu)")
        {
            // 최초스폰일 경우 사용
            StartCoroutine("EnemyDrop");
        }
    }

    //관련기획 부재로 간략하게 작성
    IEnumerator EnemyDrop()
    {
        while (EnenmySpawnCount < 10)
        {
            xPos = Random.Range(1, 50);
            yPos = Random.Range(1, 50);
            Instantiate(theEnemy, new Vector3(xPos, 50, yPos), Quaternion.identity);
            yield return new WaitForSeconds(5);
            EnenmySpawnCount++;
        }
    }

    // 지속적인 리스폰일경우 사용
    /*IEnumerator ReserveSpawn()
    {
        _reserveCount++;
        yield return new WaitForSeconds(Random.Range(0, _spawnTime));
        GameObject obj = Managers.Game.Spawn(Define.WorldObject.Monster, "DogPolyart");
        // _monsterCount를 이 함수에서 늘리지 않아도 GameManagerEx에서 Spawn함수가 실행될 때 Invoke로 _monsterCount를 늘려준다.
        NavMeshAgent nma = obj.GetOrAddComponent<NavMeshAgent>();

        Vector3 randPos;

        while (true)
        {
            Vector3 randDir = Random.insideUnitSphere * Random.Range(0, _spawnRadius);
            randDir.y = 0;
            randPos = _spawnPos + randDir;
            // 랜덤한 방향벡터를 생성한다.
            // 몬스터는 평면에 위치해야 하기 때문에 생성된 랜덤벡터의 y좌표를 0으로 만들어준다.

            NavMeshPath path = new NavMeshPath();
            if (nma.CalculatePath(randPos, path))
                break;
            // 생성된 랜덤벡터에 갈 수 있나 없나 계산
        }

        obj.transform.position = randPos;
        _reserveCount--;
    }*/
}

/*public class GameManagerEx
{
	...
    public Action<int> OnSpawnEvent;
    ...
    public GameObject Spawn(Define.WorldObject type, string path, Transform parent = null)
    {
        GameObject go = Managers.Resource.Instantiate(path, parent);
        switch (type)
        {
            case Define.WorldObject.Monster:
                _monsters.Add(go);
                if (OnSpawnEvent != null)
                    OnSpawnEvent.Invoke(1);
                break;
    }
        ...
    public void Despawn(GameObject go)
    {
        Define.WorldObject type = GetWorldObjectType(go);

        switch (type)
        {
            case Define.WorldObject.Monster:
                {
                    if (_monsters.Contains(go))
                    {
                        if (OnSpawnEvent != null)
                            OnSpawnEvent.Invoke(-1);
                        _monsters.Remove(go);
                    }
                }
}*/
