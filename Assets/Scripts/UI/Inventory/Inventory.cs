using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static bool invectoryActivated = true;

    [SerializeField]
    private GameObject go_InventoryBase; // Inventory_Base 이미지
    [SerializeField] 
    private GameObject go_SlotsParent;  // Slot들의 부모인 Grid Setting 
    [SerializeField]
    private Slot[] slots;  // 슬롯들 배열

    void Start()
    {
        slots = go_SlotsParent.GetComponentsInChildren<Slot>();
        foreach (Slot slot in slots)
        {
            slot.gameObject.SetActive(false);
        }
        
    }

      void Update()
    {
        TryOpenInventory();
    }

    private void TryOpenInventory()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            invectoryActivated = !invectoryActivated;

            if (invectoryActivated)
                OpenInventory();
            else
                CloseInventory();

        }
    }

    private void OpenInventory()
    {
        go_InventoryBase.SetActive(true);
    }

    private void CloseInventory()
    {
        go_InventoryBase.SetActive(false);
    }
    
    public void AcquireItem(Item _item)
    {
        Debug.Log(slots.Length);
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                Debug.Log(_item);
                slots[i].gameObject.SetActive(true);
                slots[i].AddItem(_item);
                return;
            }
        }
    }
}