using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinConnector : MonoBehaviour
{
    public GameObject winPanel;
    public Text winText;
    // Use this for initialization
    void Start()
    {
        GameManager.instance.winGameObject = winPanel;
        GameManager.instance.winningPlayer = winText;
    }
}
