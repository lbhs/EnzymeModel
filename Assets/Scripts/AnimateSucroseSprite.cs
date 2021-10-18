using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(ActivationEnergyResponse))]
public class AnimateSucroseSprite : MonoBehaviour
{
    private Animator sucroseRotationAnimator;
    private ActivationEnergyResponse activationEnergyResponse;

    #region Private Methods
    // Start is called before the first frame update
    void Start()
    {
        sucroseRotationAnimator = GetComponent<Animator>();
        activationEnergyResponse = GetComponent<ActivationEnergyResponse>();
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
    #endregion
}
