using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface for decision tree implementation
public interface IDecision
{
    IDecision MakeDecision();
}