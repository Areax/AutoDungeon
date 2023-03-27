using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Action
{
    public ActionEffect GetEffect(Stats playerStats);
    /*
     * Applies cooldowns if needed
     */
    public void UseAction(int currTick);
    public int GetCastTime();
    public int GetNextUsableTick();
    public string GetName();
}
