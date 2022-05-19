using UnityEngine;
using UnityEngine.UI;
using GameCookInterface;
using TMPro;
public class LobbyCanvas : CanvasUI
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _OptionButton;
    [SerializeField] private Button _CreditButton;
    [SerializeField] private Button _backButton;

    private void Start()
    {
        _playButton.onClick.AddListener(() => OnClickPlay());
        _OptionButton.onClick.AddListener(() => OnClickOptions());
        _CreditButton.onClick.AddListener(() => OnClickCredits());
        _backButton.onClick.AddListener(() => OnClickBack());
    }

    private void OnClickPlay()
    {
        SoundOnByNext();
    }
    private void OnClickOptions()
    {
        SoundOnByNext();
        Managers.Instance.CanvasManager.OpenCanvasUI(CanvasType.Options);        
    }
    private void OnClickCredits()
    {
        SoundOnByNext();
        Managers.Instance.CanvasManager.OpenCanvasUI(CanvasType.Credits);
        //AudioManager.Instance.PlayBGMSound(BGMSoundType.Credits);
    }
    private void OnClickScore()
    {
        SoundOnByNext();
        Managers.Instance.CanvasManager.OpenCanvasUI(CanvasType.Score);
    }
    protected override void OnClickBack()
    {
        
    }
    protected override void OnEnable()
    {
        base.OnEnable();
    }
}