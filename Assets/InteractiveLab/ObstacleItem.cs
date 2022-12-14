using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    private Renderer rend;
    private float changeSpeed = 0.2f;

    [Range(0f, 1f)] public float hpCurrentValue;
    private static float damage = 0.005f;

    private UnityEvent onDestroyObstacle;

    [ContextMenu("Shoot")]
    public void GetDamage()
    {
        hpCurrentValue -= damage;
        StartCoroutine(shootCoroutine(changeSpeed));
    }

    private IEnumerator shootCoroutine(float speed)
    {
        float t = 0;
        Color currentColor = transform.GetComponent<Renderer>().material.color;

        while (t < 1)
        {
            t += speed * Time.deltaTime;
            switch (hpCurrentValue)
            {
                case >= 0.7f and < 0.9f:
                    transform.GetComponent<Renderer>().material.color =
                        Color.Lerp(currentColor, new Color32(255, 200, 200, 255), t);
                    break;
                case >= 0.3f and < 0.7f:
                    transform.GetComponent<Renderer>().material.color =
                        Color.Lerp(currentColor, new Color32(255, 125, 125, 255), t);
                    break;
                case > 0.0001f and < 0.3f:
                    transform.GetComponent<Renderer>().material.color = Color.Lerp(currentColor,
                        new Color32(255, 40, 40, 255), t);
                    break;
                case <= 0.01f:
                    onDestroyObstacle.Invoke();
                    break;
            }

            yield return null;
        }
    }

    void Start()
    {
        onDestroyObstacle = new UnityEvent();
        onDestroyObstacle.AddListener(() => Destroy(gameObject, 1));
    }
}