using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class MoveSprite : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    public void OnMouseDrag()
    {
        rigidBody2D.MovePosition(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }

    public void OnMouseUp()
    {
        rigidBody2D.MovePosition(startPosition);
    }
}
