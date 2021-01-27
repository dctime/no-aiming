using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperAimAreaIndicator : MonoBehaviour
{
    [SerializeField] private Transform aimIndicatorTransform;
    [SerializeField] private float startAimAngle;
    [SerializeField] private int AimTime;
    [SerializeField] private float minAimAngle;

    private float AngleToXValue(float angle)
    {
        float XValue;
        XValue = Mathf.Tan((float)(angle / 2.0 * Mathf.PI / 180.0)) * 30 * 2;
        return XValue;
    }
    private void Update()
    {
        aimIndicatorTransform.localScale = new Vector3(AngleToXValue(startAimAngle), aimIndicatorTransform.localScale.y, aimIndicatorTransform.localScale.z);
        if (startAimAngle > minAimAngle)
            startAimAngle = startAimAngle * AimTime / (AimTime + 1);
    }

}
