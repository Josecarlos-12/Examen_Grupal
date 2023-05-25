using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBounce : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 direction;
    private RectTransform canvasRectTransform;

    void Start()
    {
        direction = Random.insideUnitCircle.normalized;

        canvasRectTransform = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime, Space.Self);

        Vector3 canvasMin = canvasRectTransform.rect.min;
        Vector3 canvasMax = canvasRectTransform.rect.max;

        if (transform.localPosition.x >= canvasMax.x || transform.localPosition.x <= canvasMin.x)
        {
            direction.x = -direction.x;
        }

        if (transform.localPosition.y >= canvasMax.y || transform.localPosition.y <= canvasMin.y)
        {
            direction.y = -direction.y;
        }
    }
}
