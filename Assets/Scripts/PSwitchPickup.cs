using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PSwitchState : byte
{
    Active,
    Inactive
}
public class PSwitchPickup : Pickup
{
    protected PSwitchState switchState;
    // Start is called before the first frame update
    void Start()
    {
        pickupType = EPickupType.PSwitch;
        switchState = PSwitchState.Inactive;
        Animator animator = GetComponent<Animator>();
        animator.Play("P-SwitchOn");
    }

    public void Activate()
    {
        switchState = PSwitchState.Active;
        Animator animator = GetComponent<Animator>();
        animator.Play("P-SwitchOff");
    }

}
