using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject snemy;




    void SpawnEnemy()

    {

        Vector3 playerPosition = GameObject.FindWithTag("Character").transform.position; //플레이어 포지션을 가져오는 부분

        float randomX = Random.Range(-20.5f, -10.5f); //적이 나타날 X좌표를 랜덤으로 생성해 줍니다.

        float randomZ = Random.Range(-30.5f, 30.5f); // 적이 나타날 Z좌표를 랜덤으로!

        GameObject enemy = (GameObject)Instantiate(snemy, new Vector3(playerPosition.x + randomX, playerPosition.y, playerPosition.z + randomZ), Quaternion.identity); //오브잭트 생성부분



   }

    void Start()
    {

        InvokeRepeating("SpawnEnemy", 12f, 10f); //3초후 부터, SpawnEnemy함수를 2초마다 반복해서 실행 시킵니다.

    }





  
}
