using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class SetLevelObjective : MonoBehaviour
{
    [SerializeField] private int totalObjective;
    void Start()
    {
        PointManager.Instance.SetItemObjective(totalObjective);
        PointManager.Instance.SetText();   
    }
}
