using UnityEngine;

public class InteractiveBox : MonoBehaviour
{
    [SerializeField] private LayerMask obstacleLayerMask;
    [SerializeField] InteractiveBox next;

    public void AddNext(InteractiveBox box)
    {
        next = box;
    }

    void FixedUpdate()
    {
        if (next)
        {
            Debug.DrawLine(transform.position, next.transform.position, Color.red, 0.5f, true);

            if (Physics.Linecast(transform.position, next.transform.position,
                    out RaycastHit hit, obstacleLayerMask))
            {
                if (hit.collider.gameObject.TryGetComponent(out ObstacleItem item))
                {
                    item.GetDamage();
                }
            }
        }
    }
}