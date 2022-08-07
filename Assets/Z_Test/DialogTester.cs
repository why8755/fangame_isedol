using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GameCookInterface;

public class DialogTester : MonoBehaviour
{
    enum testLayer { NPC = 9 } // �׽�Ʈ��


    // �ֺ� NPC Ž�� ����
    [SerializeField] float searchRange = 5.0f;
    // ��ȣ�ۿ� UI
    [SerializeField] Image pressKey;
    [SerializeField] TextMeshProUGUI keyText;
    // Ž���� layer
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

        // �ڱ� �ڽ� �߽����� searchRange ��ŭ�� ���� ���� ���� NPC ���̾ ���� Collider Ž��
        Collider[] npc = Physics.OverlapSphere(pos, searchRange, layer);

        if (npc.Length >= 1)
        {
            pressKey.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                // ���� ���� ������ enum���̶� ���� ���밪�̶� �ٸ� (CanvsType.Lobby)
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
