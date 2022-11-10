using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteScript : SampleScript
{
    [Min(0.01f)] [SerializeField] private float speed = 1f;

    [SerializeField]
    private Transform target;

    [ContextMenu("Начать процесс")]
    public override void Use()
    {
        StopAllCoroutines();
        StartCoroutine(DeletionObjects());
    }

    private IEnumerator DeletionObjects()
    {
        Vector3 targetVectorSize = new Vector3(0f, 0f, 0f);
        while (target.childCount > 0)
        {
            var obj = target.GetChild(Random.Range(0, target.childCount - 1)).gameObject;
            Vector3 start = obj.transform.lossyScale;

            float t = 0;
            while (t < 1)
            {
                t += Time.deltaTime * speed;
                obj.transform.localScale = Vector3.Lerp(start, targetVectorSize, t);

                yield return null;
            }

            Destroy(obj);
            yield return new WaitForFixedUpdate();
        }
    }
}
