using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayOption : MonoBehaviour
{
    public GameObject canvas;

    public Dropdown resolutionDropdown;
    public Toggle fullScreenToggle;

    List<Resolution> resolutions = new List<Resolution>();

    FullScreenMode fullScreen;

    int resolutionNum;

    private void Awake()
    {
        DropdownSetting();
    }

    void DropdownSetting()
    {
        int displayOptionNum = 0;

        /*
        // �ػ� ����
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            if (Screen.resolutions[i].refreshRate <= 60)
            {
                resolutions.Add(Screen.resolutions[i]);
            }
        }
        */

        // �ػ� �߰�
        resolutions.AddRange(Screen.resolutions);

        // ��Ӵٿ� �ʱ�ȭ
        resolutionDropdown.options.Clear(); 

        foreach(Resolution content in resolutions)
        {
            Dropdown.OptionData data = new Dropdown.OptionData();

            // �ػ� ���� ex) 1920 X 1080
            data.text = content.width + " X " + content.height;

            // ��Ӵٿ ������ �߰�
            resolutionDropdown.options.Add(data); 

            if (content.width == Screen.width && content.height == Screen.height)
            {
                resolutionDropdown.value = displayOptionNum;
                displayOptionNum++;
            }

        }
        // ���ΰ�ħ
        resolutionDropdown.RefreshShownValue(); 

        // ���� ��üȭ������ �ƴ���
        fullScreenToggle.isOn = Screen.fullScreenMode.Equals(FullScreenMode.FullScreenWindow) ? true : false;

    }

    public void DropdownOptionNumber(int x)
    {
        resolutionNum = x;
    }

    public void FullScreen(bool isFull)
    {
        fullScreen = isFull ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed;
    }

    public void AgreeButton()
    {
        Screen.SetResolution(resolutions[resolutionNum].width, resolutions[resolutionNum].height, fullScreen);
    }

    public void ExitUI()
    {
        canvas.SetActive(false);
    }

}
