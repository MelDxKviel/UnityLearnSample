using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToshiboSampleScript : SampleScript
{
    private Vector3 startPosition;
    private bool key;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }
    // Update is called once per frame
    private void Update()
    {
        if (key)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (transform.position == targetPosition)
            {
                key = false;
            }
        }
    }
   
    public Vector3 targetPosition = new Vector3(3, 0, 0);
    public float speed = 1;
    [ContextMenu("USE")]
    public override void Use()
    {
        key = true;
    }
}
