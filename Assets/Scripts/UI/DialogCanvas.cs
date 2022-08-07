using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogCanvas : CanvasUI
{
    [SerializeField]
    Image dialogBox, nameBox;

    [SerializeField]
    TextMeshProUGUI dialogText, nameText;

    [SerializeField]
    testDialog dialogDB;

    int curDialogIndex = -1;

    
    private IEnumerator Start()
    {
        yield return new WaitUntil(() => UpdateDialog());
    }

    public bool UpdateDialog()
    {
        //NextDialog();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (dialogDB.Sheet1.Count > curDialogIndex + 1) NextDialog();
            else
            {
                Managers.Instance.CanvasManager.CloseCanvasUI();
                return true;
            }
        }

        return false;
    }

    void NextDialog()
    {

        curDialogIndex++;

        dialogText.text = dialogDB.Sheet1[curDialogIndex].dialog;
        nameText.text = dialogDB.Sheet1[curDialogIndex].name;
    }

}
