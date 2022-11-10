using System.Collections;
using UnityEngine;

public class RotateScript : SampleScript
{
    [SerializeField]
    private Quaternion targetRotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
    [SerializeField]
    private float changeSpeed = 10;

    private Quaternion defaultRotation;
    private Transform targetTransform;
    

    private void Start()
    {
        targetTransform = transform;
        defaultRotation = targetTransform.localRotation;
    }

    [ContextMenu("Use")]
    public override void Use()
    {
        StopAllCoroutines();
        StartCoroutine(RotateCoroutine(targetRotation));
    }

    [ContextMenu("Reset To Default State")]
    public void ReturnToDefaultState()
    {
        StopAllCoroutines();
        StartCoroutine(RotateCoroutine(defaultRotation));
    }

    private IEnumerator RotateCoroutine(Quaternion target)
    {
        Quaternion start = targetTransform.localRotation;
        float t = 0;
        while(t < 1)
        {
            t += Time.deltaTime * changeSpeed / 100;
            targetTransform.localRotation = Quaternion.Lerp(start, target, t);
            yield return null;
        }
        targetTransform.localRotation = target;
    }
}