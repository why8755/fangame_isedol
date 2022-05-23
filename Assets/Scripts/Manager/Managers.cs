using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : Singleton<Managers>
{
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private CanvasManager canvasManager;
    [SerializeField] private DataManager dataManager;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public SoundManager SounaManager { get { return soundManager; }}
    public CanvasManager CanvasManager { get { return canvasManager; }}
    public DataManager DataManager { get { return dataManager; }}


}
