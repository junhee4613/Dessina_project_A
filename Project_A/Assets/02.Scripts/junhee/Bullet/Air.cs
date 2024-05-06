using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Air : MonoBehaviour, IInterection_obj
{
    public void Interaction()
    {
        Managers.UI.air_gauge.value += Managers.GameManager.air_data.air_Levels[0].simple_air;
        Managers.Pool.Push(gameObject);
    }
}
