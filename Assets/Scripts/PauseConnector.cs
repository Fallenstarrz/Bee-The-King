using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseConnector : MonoBehaviour
{
    public GameObject pauseMenu;

    // Use this for initialization
    void Start()
    {
        GameManager.instance.pauseMenu = pauseMenu;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
