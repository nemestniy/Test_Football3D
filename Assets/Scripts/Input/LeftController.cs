using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftController : InputManager
{
    public override event ClickEvents Kick;

    public override Vector3 GetVelocity()
    {
        return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            Kick();
    }
}
