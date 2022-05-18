using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyperlinks : MonoBehaviour
{
    public void OpenDiscord()
    {
        Application.OpenURL("https://discord.gg/6GYzahWD");
    }
    public void OpenURL(string link)
    {
        Application.OpenURL(link);
    }
}
