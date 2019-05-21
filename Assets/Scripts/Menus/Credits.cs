using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1;
    [SerializeField]
    private GameObject creditsPrefab;

    public SceneSwitcher mySceneSwitcher;

    private void Start()
    {
        creditsPrefab = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        creditsPrefab.transform.Translate(Vector3.up * (moveSpeed * Time.deltaTime));

        if (Input.anyKeyDown)
        {
            returnToMainMenu();
        }
    }

    void returnToMainMenu()
    {
        mySceneSwitcher.loadScene("MainMenuScene");
    }
}
