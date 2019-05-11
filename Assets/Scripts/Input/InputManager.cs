using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputManager : MonoBehaviour
{
    public delegate void ClickEvents();
    public abstract event ClickEvents Kick;

    public abstract Vector3 GetVelocity();
}
