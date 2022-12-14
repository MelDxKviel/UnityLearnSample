using System.Collections;
using UnityEngine;

public class InteractiveRaycast : MonoBehaviour
{
    public GameObject box;
    public GameObject obstacle;
    
    private new Camera camera;

    InteractiveBox thisBox;
    
    private IEnumerator onClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var raycastHit, 100f))
            {
                if (raycastHit.transform is not null)
                {
                    if (raycastHit.transform.CompareTag("InteractivePlane"))
                    {
                        Instantiate(box, raycastHit.point + raycastHit.normal / 2, new Quaternion());
                    }

                    if (raycastHit.transform.TryGetComponent<InteractiveBox>(out var boxItem))
                    {
                        if (thisBox is null)
                        {
                            thisBox = boxItem;
                        }
                        else
                        {
                            thisBox.gameObject.GetComponent<InteractiveBox>().AddNext(boxItem);
                            thisBox = null;
                        }
                    }
                }
            }
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var raycastHit, 100f))
            {
                if (raycastHit.transform is not null)
                {
                    if (raycastHit.transform.TryGetComponent<InteractiveBox>(out var boxItem))
                    {
                        Destroy(raycastHit.transform.gameObject);
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            var ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var raycastHit, 100f))
            {
                if (raycastHit.transform is not null)
                {
                    if (raycastHit.transform.CompareTag("InteractivePlane"))
                    {
                        Instantiate(obstacle, raycastHit.point + raycastHit.normal / 2, new Quaternion());
                    }
                }
            }
        }

        yield return null;
    }
    
    private void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        StartCoroutine(onClick());
    }
}