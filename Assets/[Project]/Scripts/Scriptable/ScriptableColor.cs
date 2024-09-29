using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum ColorType
{
    None,
    Gold,
    Evile,
}

[CreateAssetMenu(fileName = "Ball")]
public class ScriptableColor : ScriptableObject
{
    public ColorType type;
    public Color color;
}
