using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SubstrateEnzymeProperties : MonoBehaviour
{
    // The energy required to break the bond in the substrate
    // Without the enzyme
    public float substrateActivationEnergyNoEnzyme;
    // The change in the required activation energy
    // Caused by the enzyme
    // Positive value
    [Min(0f)]
    public float enzymeChangeInActivationEnergy;
    public float netRequiredActivationEnergy
    {
        get
        {
            float result = substrateActivationEnergyNoEnzyme - enzymeChangeInActivationEnergy;
            return result;
        }
    }
}
