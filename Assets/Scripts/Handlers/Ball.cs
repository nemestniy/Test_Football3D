using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Player _lastPlayer;

    public Player GetLastPlayer()
    {
        return _lastPlayer;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
            _lastPlayer = collision.transform.GetComponent<Player>();
    }
}
