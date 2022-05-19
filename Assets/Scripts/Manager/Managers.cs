using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : Singleton<Managers>
{
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private CanvasManager canvasManager;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public SoundManager SounaManager { get { return soundManager; }}
    public CanvasManager CanvasManager { get { return canvasManager; }}


}
