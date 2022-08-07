using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameCookInterface;

public class DialogTester : MonoBehaviour
{
    enum testLayer { NPC = 9 } // 테스트용


    // 주변 NPC 탐색 범위
    [SerializeField] float searchRange = 5.0f;
    // 상호작용 UI
    [SerializeField] Image pressKey;
    [SerializeField] TextMeshProUGUI keyText;
    // 탐색할 layer
    [SerializeField] LayerMask layer;

    [SerializeField] GameObject defaultCamera, dialogCamera;

    Vector3 pos;

    private void Awake()
    {
        pressKey.gameObject.SetActive(false);
        
    }

    void Update()
    {
        CheckNPC();
    }

    void CheckNPC()
    {
        pos = transform.position + new Vector3(0.0f, 1.0f, 0.0f);

        // 자기 자신 중심으로 searchRange 만큼의 원형 범위 안의 NPC 레이어를 가진 Collider 탐색
        Collider[] npc = Physics.OverlapSphere(pos, searchRange, layer);

        if (npc.Length >= 1)
        {
            pressKey.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                // 현재 정렬 때문에 enum값이랑 실제 적용값이랑 다름 (CanvsType.Lobby)
                Managers.Instance.CanvasManager.OpenCanvasUI(CanvasType.Lobby);
                defaultCamera.SetActive(false);
                dialogCamera.SetActive(true);
                pressKey.gameObject.SetActive(false);

            }

        }
        else
        {
            dialogCamera.SetActive(false);
            defaultCamera.SetActive(true);
            pressKey.gameObject.SetActive(false);
        }
            

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(pos, searchRange);
    }

}
