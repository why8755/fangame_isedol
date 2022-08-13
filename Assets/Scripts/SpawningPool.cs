using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class SpawningPool : MonoBehaviour
{
    //���ñ�ȹ ����� �����ϰ� �ۼ�
    public GameObject theEnemy;
    public int EnenmySpawnCount;
    public int xPos;
    public int yPos;

    /* [SerializeField]
     int _monsterCount = 0; // ���� Enemy ��
     int _reserveCount = 0; // �ڷ�ƾ�� ������ �� ���� ����� �ڷ�ƾ�� ����� �Ǵ��ϱ� ����
     [SerializeField]
     int _keepMonsterCount = 5;  // �ʵ忡 �ִ� Enemy ��
     [SerializeField]
     Vector3 _spawnPos; // Spawn ��ġ
     [SerializeField]
     float _spawnRadius = 15.0f; // Spawn ����
     [SerializeField]
     float _spawnTime = 5.0f; // ����*/

    //public void AddMonsterCount(int value) { _monsterCount += value; }
    //public void SetKeepMonsterCount(int count) { _keepMonsterCount = count; }

    void Start()
    {
        
    }

    void Update()
    {
        // �������� ������ ��� ���
        /*while (_reserveCount + _monsterCount < _keepMonsterCount)
        // ���� ������ ���� ����� �ڷ�ƾ�� ���� _keepMonsterCount���� ���ٸ� �ڷ�ƾ ����
        {
            StartCoroutine("ReserveSpawn");
        }*/
    }

    private void OntriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player(Gosegu)")
        {
            // ���ʽ����� ��� ���
            StartCoroutine("EnemyDrop");
        }
    }

    //���ñ�ȹ ����� �����ϰ� �ۼ�
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

    // �������� �������ϰ�� ���
    /*IEnumerator ReserveSpawn()
    {
        _reserveCount++;
        yield return new WaitForSeconds(Random.Range(0, _spawnTime));
        GameObject obj = Managers.Game.Spawn(Define.WorldObject.Monster, "DogPolyart");
        // _monsterCount�� �� �Լ����� �ø��� �ʾƵ� GameManagerEx���� Spawn�Լ��� ����� �� Invoke�� _monsterCount�� �÷��ش�.
        NavMeshAgent nma = obj.GetOrAddComponent<NavMeshAgent>();

        Vector3 randPos;

        while (true)
        {
            Vector3 randDir = Random.insideUnitSphere * Random.Range(0, _spawnRadius);
            randDir.y = 0;
            randPos = _spawnPos + randDir;
            // ������ ���⺤�͸� �����Ѵ�.
            // ���ʹ� ��鿡 ��ġ�ؾ� �ϱ� ������ ������ ���������� y��ǥ�� 0���� ������ش�.

            NavMeshPath path = new NavMeshPath();
            if (nma.CalculatePath(randPos, path))
                break;
            // ������ �������Ϳ� �� �� �ֳ� ���� ���
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
