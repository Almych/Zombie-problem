
using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    public LayerMask collectable;

    private void Awake()
    {
        UpdateSystem.OnUpdate += Tick;
    }

    private void OnDestroy()
    {
        UpdateSystem.OnUpdate -= Tick;
    }
    private void Tick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, Mathf.Infinity, collectable);

            if (hit.collider != null && hit.collider.GetComponent<ICollectable>() != null)
            {
                hit.collider.GetComponent<ICollectable>().OnCollect();
            }
        }
    }
}
