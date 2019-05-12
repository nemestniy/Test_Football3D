using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private float _speedTracking;
    private Transform _trackingObject;
    private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = transform.position;
    }

    public void SetTrackingObject(Transform trackingObject)
    {
        _trackingObject = trackingObject;
    }

    public void NextGame()
    {
        transform.position = _startPosition;
    }

    private void Update()
    {
        if (_trackingObject != null)
        {
            var movePosition = new Vector3(_trackingObject.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, movePosition, _speedTracking * Time.deltaTime);
        }
    }
}
