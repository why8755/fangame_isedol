using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using GameCookInterface;

public class CanvasManager : MonoBehaviour
{

    public delegate void CanvasActiveHandler();
    public static event CanvasActiveHandler ActiveEventCall;

    [SerializeField]
    private List<CanvasUI> canvasUIPrefabs;

    [Header("UI Canvas Reference")]
    [SerializeField]
    private List<CanvasUI> canvasReference = new List<CanvasUI>();
    private static List<CanvasUI> canvasTemporary = new List<CanvasUI>();


    [Header("Canvas Transform")]
    [SerializeField] private Transform _canvasContainer;

    private Stack<int> _stackCanvasIndex = new Stack<int>();
    public int stackCount;

    IEnumerable<CanvasUI> orderByResult = from canvas in canvasTemporary
                                          orderby canvas.CanvasIndex
                                          select canvas;
    private void Start()
    {
        Initialization();
    }
    private void SortCanvasIndex()
    {
        foreach (CanvasUI canvas in orderByResult)
        {
            canvasReference.Add(canvas);
            canvas.transform.SetParent(_canvasContainer);
        }
    }
    private void AddTemporary(CanvasUI canvas, int index)
    {
        canvas.CanvasIndex = index;
        canvasTemporary.Add(canvas);
    }
    private void Initialization() // CanvasTypeToIndex �� ��ġ
    {
        foreach (CanvasUI canvas in canvasUIPrefabs)
        {
            AddTemporary(Instantiate(canvas) as CanvasUI, canvas.canvasType.CanvasTypeToIndex());
        }
        SortCanvasIndex();
        OpenCanvasUI(CanvasType.Login);
        //AudioManager.Instance.PlayMusic(MusicType.Login);
    }

    public void OpenCanvasUI(CanvasType type)
    {
        if (canvasReference[type.CanvasTypeToIndex()] != null)
        {
            ActiveEventCall(); // ���� �����ִ� �ٸ� canvas �ݱ�
            canvasReference[type.CanvasTypeToIndex()].gameObject.SetActive(true);
            _stackCanvasIndex.Push(type.CanvasTypeToIndex());
        }
        stackCount = _stackCanvasIndex.Count;
    }
    public void CloseCanvasUI()
    {
        int index = _stackCanvasIndex.Pop();
        if (_stackCanvasIndex.Count > 0)
        { // ������ ���� 0�� ���� ������ �ʴ´�.
            index = _stackCanvasIndex.Peek();
            ActiveEventCall();
            canvasReference[index].gameObject.SetActive(true);
        }
        stackCount = _stackCanvasIndex.Count;
    }
}