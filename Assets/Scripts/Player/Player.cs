using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _kickRate;

    public Transform _ball;
    private Rigidbody _rigidbody;
    private InputManager _inputManager;
    private Team _team;

    public void InitializateTeam(Team team)
    {
        _team = team;
        _inputManager = team.GetInputManager();
        _inputManager.Kick += _inputManager_Kick;
        GetComponent<Renderer>().material.color = team.GetColor();
    }

    public Team GetTeam()
    {
        return _team;
    }

    public void Respawn(Vector3 position)
    {
        _rigidbody.constraints = RigidbodyConstraints.None;
        transform.position = position;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void _inputManager_Kick()
    {
        Kick();
    }

    private void Update()
    {
        //Передвижение игрока
        SetVelocity(_inputManager.GetVelocity() * _speed);
    }

    public void SetVelocity(Vector3 velocity)
    {
        _rigidbody.velocity = new Vector3(velocity.x, _rigidbody.velocity.y, velocity.z);
    }

    public void Kick()
    {
        if (_ball != null)
        {
            //Удар по мячу в направлении движения игрока
            _ball.GetComponent<Rigidbody>().AddForce(_inputManager.GetVelocity() * _kickRate);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Field")
        {
            if (_rigidbody.constraints != RigidbodyConstraints.FreezePositionY)
                _rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        }

        if (collision.transform.tag == "Ball")
            _ball = collision.transform;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Ball")
            _ball = null;
    }
}
