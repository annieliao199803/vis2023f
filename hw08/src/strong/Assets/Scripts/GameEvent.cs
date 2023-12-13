using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public delegate void OccurReadAllDataComplete();
    public static OccurReadAllDataComplete OnReadAllDataComplete;
}
