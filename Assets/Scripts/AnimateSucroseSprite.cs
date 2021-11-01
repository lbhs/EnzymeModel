using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(ActivationEnergyResponse))]
[RequireComponent(typeof(Rigidbody2D))]
public class AnimateSucroseSprite : MonoBehaviour
{
    private Animator sucroseRotationAnimator;
    private ActivationEnergyResponse activationEnergyResponse;
    private Rigidbody2D rigidbody2d;

    #region Private Methods

    void Awake()
    {
        EventManager.bondBreakSuccess += MoveSpriteOnBondBreakSuccess;
    }

    // Start is called before the first frame update
    void Start()
    {
        sucroseRotationAnimator = GetComponent<Animator>();
        activationEnergyResponse = GetComponent<ActivationEnergyResponse>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        sucroseRotationAnimator.SetTrigger("Move_Sucrose");

        // TODO: Create generic HasComponent<T>() method to eliminate boilerplate null check
        ActivationEnergy activationEnergy = collider2D.gameObject.GetComponent<ActivationEnergy>();
        if (activationEnergy != null)
            activationEnergyResponse.RespondToActivationEnergy(activationEnergy.activationEnergy);
    }

    private void MoveSpriteOnBondBreakSuccess()
    {
        Vector2 targetPosition = new Vector2(2500f, 2500f);
        rigidbody2d.MovePosition(targetPosition);
    }
    #endregion
}
