using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperAimAreaIndicator : MonoBehaviour
{
    [SerializeField] private Transform aimIndicatorTransform;
    [SerializeField] private float startAimAngle;
    [SerializeField] private int AimTime;
    [SerializeField] private float minAimAngle;

    //暫存startAimAngle
    private float tempStartAimAngle;

    //tempStartAimAngle Getter，給SniperRifleFire
    public float AimIndicatorAngle_Getter()
    {
        return tempStartAimAngle;
    }

    private float AngleToXValue(float angle)
    {
        float XValue;
        XValue = Mathf.Tan((float)(angle / 2.0 * Mathf.PI / 180.0)) * 30 * 2;
        return XValue;
    }
    private void Awake()
    {
        tempStartAimAngle = startAimAngle;
    }
    private void Update()
    {
        aimIndicatorTransform.localScale = new Vector3(AngleToXValue(tempStartAimAngle), aimIndicatorTransform.localScale.y, aimIndicatorTransform.localScale.z);
        if (tempStartAimAngle > minAimAngle)
            tempStartAimAngle = tempStartAimAngle * AimTime / (AimTime + 1);
    }

    private void OnEnable()
    {
        tempStartAimAngle = startAimAngle;
    }

}
