using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SubstrateEnzymeProperties))]
public class ActivationEnergyResponse : MonoBehaviour
{
    private float requiredActivationEnergy;

    // Start is called before the first frame update
    void Start()
    {
        requiredActivationEnergy = GetComponent<SubstrateEnzymeProperties>().netRequiredActivationEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespondToActivationEnergy(float providedActivationEnergy)
    {
        if (BondEnergyManager.DetermineWhetherToBreakBond(providedActivationEnergy, requiredActivationEnergy))
            EventManager.bondBreakSuccess();
        else
            EventManager.bondBreakFailure();
    }
}
