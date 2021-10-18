using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BondEnergyManager
{
    public static bool DetermineWhetherToBreakBond(float providedActivationEnergy, float requiredActivationEnergy)
    {
        float randomPick = UnityEngine.Random.Range(0f, 10f);

        // 20% probability of the bond being broken if the provided activation energy is insufficient
        // 80% probability if the activation energy is sufficient

        if (providedActivationEnergy < requiredActivationEnergy)
            return randomPick < 2f;
        return randomPick < 8f;
    }
}
