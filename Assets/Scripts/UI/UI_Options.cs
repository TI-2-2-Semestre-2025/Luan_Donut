using System;
using UnityEditor;
using UnityEngine;

public class UI_Options : MonoBehaviour
{
    private void Start()
    {
        Game_Manager.Instance.UI_Options = this;
        gameObject.SetActive(false);
    }

    public void OpenOptions()
    {
        gameObject.SetActive(true);
    }

    public void CloseOptions()
    {
        gameObject.SetActive(false);
    }
}
