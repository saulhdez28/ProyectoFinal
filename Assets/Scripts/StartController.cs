using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartController : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textbox;
    public void Play()
    {
        StateManager.Instance.setName(textbox.text);
        LevelManager.Instance.NextScene();
    }
}