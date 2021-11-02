using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(ActivationEnergyResponse))]
public class AnimateSucroseSprite : MonoBehaviour
{
    private Animator sucroseRotationAnimator;
    private ActivationEnergyResponse activationEnergyResponse;

    private Collider2D collidedObject;

    #region Private Methods
    // Start is called before the first frame update
    void Start()
    {
        sucroseRotationAnimator = GetComponent<Animator>();
        activationEnergyResponse = GetComponent<ActivationEnergyResponse>();
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        sucroseRotationAnimator.SetTrigger("Move_Sucrose");
        collidedObject = collider2D;
    }

    // Animation callback
    // Refer to the Animation Event at the end of the Sucrose Rotation Animation
    private void OnAnimationComplete()
    {
        Debug.Log("Animation complete.");

        ActivationEnergy activationEnergy = collidedObject?.gameObject.GetComponent<ActivationEnergy>();
        if (activationEnergy != null)
            activationEnergyResponse.RespondToActivationEnergy(activationEnergy.activationEnergy);
    }
    #endregion
}
