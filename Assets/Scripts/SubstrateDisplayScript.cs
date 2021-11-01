using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class SubstrateDisplayScript : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;

    void Awake()
    {
        EventManager.bondBreakSuccess += MoveSpriteOnBondBreakSuccess;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    private void MoveSpriteOnBondBreakSuccess()
    {
        Vector2 targetPosition = new Vector2(2500f, 2500f);
        rigidbody2d.MovePosition(targetPosition);
    }
}
