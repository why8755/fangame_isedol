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

    bool typing;
    float typingSpeed = 0.2f;


    private IEnumerator Start()
    {
        yield return new WaitUntil(() => UpdateDialog());
    }

    public bool UpdateDialog()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (typing)
            {
                typing = false;

                StopCoroutine("TypingEffect");
                dialogText.text = dialogDB.Sheet1[curDialogIndex].dialog;

                return false;
            }

            if (dialogDB.Sheet1.Count > curDialogIndex + 1) NextDialog();
            else return true;

        }

        return false;
    }

    void NextDialog()
    {

        curDialogIndex++;

        //dialogText.text = dialogDB.Sheet1[curDialogIndex].dialog;
        nameText.text = dialogDB.Sheet1[curDialogIndex].name;

        StartCoroutine("TypingEffect");
    }

    IEnumerator TypingEffect()
    {
        int _index = 0;
        typing = true;

        while (_index < dialogDB.Sheet1[curDialogIndex].dialog.Length)
        {
            dialogText.text = dialogDB.Sheet1[curDialogIndex].dialog.Substring(0, _index + 1);

            _index++;

            yield return new WaitForSeconds(typingSpeed);
        }
        typing = false;

    }

}
