using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private int id;
    public string itemName;
    public string description;
    public Sprite itemImage; // 아이템의 이미지(인벤 토리 안에서 띄울)
    public GameObject itemPrefab;  // 아이템의 프리팹 (아이템 생성시 프리팹으로 찍어냄)

    public int getID() { return this.id;}
    public string getName() { return this.name;}
}
