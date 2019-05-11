using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightController : InputManager
{
    public override event ClickEvents Kick;

    public override Vector3 GetVelocity()
    {
        return new Vector3(Input.GetAxis("HorizontalR"), 0, Input.GetAxis("VerticalR"));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightControl))
            Kick();
    }
}
