using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenDisabler : MonoBehaviour
{
    private GameObject objectToDisable;
    [SerializeField]
    private GameObject menuToEnable;

    // Use this for initialization
    void Start()
    {
        objectToDisable = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            objectToDisable.SetActive(false);
            menuToEnable.SetActive(true);
        }
    }
}
