using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableObject : Interactables
{
    [SerializeField] private float _distanceLetGo = 1.5f;

    private Player _player;
    private Vector3 _delta;
    private bool _moving;
    private Rigidbody2D _myRigidbody;

    // Start is called before the first frame update
    private void Start() {
        _player = FindObjectOfType<Player>();
        _myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (_myRigidbody.bodyType == RigidbodyType2D.Dynamic && _moving) {
            if (Vector2.Distance(transform.position, _player.transform.position) > _distanceLetGo) {
                ToggleMove();
            }
        }
    }
    private void FixedUpdate() {
        if (_myRigidbody.bodyType == RigidbodyType2D.Dynamic && _moving) {
            _myRigidbody.velocity = _player.gameObject.GetComponent<Rigidbody2D>().velocity;
        }
    }

    public void ToggleMove() {
        if (_myRigidbody.bodyType == RigidbodyType2D.Dynamic) {
            _moving = !_moving;
            _player.ToggleIsCarrying();
            _player.SetPushableObject(GetComponent<PushableObject>());
            _delta = transform.position - _player.transform.position;
            _delta = new Vector3(_delta.x, _delta.y, _delta.z);
        }

    }

    public void SetStatic() {
        _myRigidbody.bodyType = RigidbodyType2D.Static;
        if (_moving) {
            ToggleMove();
            _player.ToggleIsCarrying();
        }
    }

    public void SetDynamic() {
        _myRigidbody.bodyType = RigidbodyType2D.Dynamic;
    }

}
