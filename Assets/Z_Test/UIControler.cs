using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCookInterface;

public class UIControler : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            Managers.Instance.CanvasManager.OpenCanvasUI(CanvasType.Login);
        }

        if (Input.GetKeyDown("2"))
        {
            Managers.Instance.CanvasManager.OpenCanvasUI(CanvasType.Intro);
        }

        if (Input.GetKeyDown("3"))
        {
            Managers.Instance.CanvasManager.OpenCanvasUI(CanvasType.Lobby);
        }

        if (Input.GetKeyDown("4"))
        {
            Managers.Instance.CanvasManager.OpenCanvasUI(CanvasType.Options);
        }

        if (Input.GetKeyDown("5"))
        {
            Managers.Instance.CanvasManager.OpenCanvasUI(CanvasType.Dialogs);
        }

    }
}
