using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject snemy;




    void SpawnEnemy()

    {

        Vector3 playerPosition = GameObject.FindWithTag("Character").transform.position; //�÷��̾� �������� �������� �κ�

        float randomX = Random.Range(-20.5f, -10.5f); //���� ��Ÿ�� X��ǥ�� �������� ������ �ݴϴ�.

        float randomZ = Random.Range(-30.5f, 30.5f); // ���� ��Ÿ�� Z��ǥ�� ��������!

        GameObject enemy = (GameObject)Instantiate(snemy, new Vector3(playerPosition.x + randomX, playerPosition.y, playerPosition.z + randomZ), Quaternion.identity); //������Ʈ �����κ�



   }

    void Start()
    {

        InvokeRepeating("SpawnEnemy", 12f, 10f); //3���� ����, SpawnEnemy�Լ��� 2�ʸ��� �ݺ��ؼ� ���� ��ŵ�ϴ�.

    }





  
}
