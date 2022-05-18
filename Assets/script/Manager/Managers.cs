using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : Singleton<Managers>
{
    [SerializeField] private SoundManager soundManager;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public SoundManager SounaManager { get { return soundManager; }}


}
