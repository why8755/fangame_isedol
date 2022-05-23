using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCookInterface;
using UnityEngine.UI;

public class SelectCharacter : MonoBehaviour
{
    [SerializeField] private CharacterType characterType;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => Select());
    }

    public void Select()
    {
        Managers.Instance.DataManager.CurrentCharacter = characterType;
        Debug.Log(Managers.Instance.DataManager.CurrentCharacter);
    }
}
