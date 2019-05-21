using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerPawn myPawn;

    public enum InputMapping
    {
        keyboard,
        controller
    }
    public InputMapping myInput;

    // Update is called once per frame
    void Update()
    {
        switch (myInput)
        {
            case InputMapping.keyboard:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    GameManager.instance.togglePaused();
                }
                break;
            case InputMapping.controller:
                if (Input.GetKeyDown(KeyCode.Joystick1Button7))
                {
                    GameManager.instance.togglePaused();
                }
                break;
            default:
                break;
        }
        if (GameManager.instance.isPaused)
        {
            return;
        }
        switch (myInput)
        {
            case InputMapping.keyboard:
                keyboardHandler();
                break;
            case InputMapping.controller:
                controllerHandler();
                break;
            default:
                break;
        }
    }

    void controllerHandler()
    {
        if (myPawn != null)
        {
            myPawn.move(Input.GetAxis("HorizontalController"));
            if (Input.GetButtonDown("JumpController"))
            {
                myPawn.jump();
            }
            if (Input.GetButtonDown("ShootController"))
            {
                myPawn.shoot();
            }
            myPawn.aimTowards(new Vector3(Input.GetAxis("AimHorizontal"), Input.GetAxis("AimVertical"), 0.0f));
        }
    }

    void keyboardHandler()
    {
        if (myPawn != null)
        {
            myPawn.move(Input.GetAxis("Horizontal"));
            if (Input.GetButtonDown("Jump"))
            {
                myPawn.jump();
            }
            if (Input.GetButtonDown("Shoot"))
            {
                myPawn.shoot();
            }
            myPawn.aimTowards(Input.mousePosition);
        }
    }
}
