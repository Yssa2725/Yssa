using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Image SoundOn;
    [SerializeField] Image SoundOff;
    private bool muted = false;
    void Start()
    {
        if(!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButonIcon();
        AudioListener.pause = muted;
    }

    public void OnButtonPress()
    {
        if(muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }
        Save();
        UpdateButonIcon();
    }

    private void UpdateButonIcon()
    {
        if(muted == false)
        {
            SoundOn.enabled = true;
            SoundOff.enabled = false;
        }
        else
        {
            SoundOn.enabled = false;
            SoundOff.enabled = true;
        }
    }
     private void Load()
        {
        muted = PlayerPrefs.GetInt("muted") == 1;
        }
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
}
