using UnityEngine;

[ExecuteAlways]
public class MinimapTracker : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] RectTransform map;
    [SerializeField] RectTransform marker;
    [SerializeField] Vector2 worldMin;
    [SerializeField] Vector2 worldMax;

    void LateUpdate()
    {
        if (target == null || map == null || marker == null) return;

        Vector2 size = map.rect.size;
        float x = Mathf.InverseLerp(worldMin.x, worldMax.x, target.position.x);
        float y = Mathf.InverseLerp(worldMin.y, worldMax.y, target.position.y);
        marker.anchoredPosition = new Vector2(
            Mathf.Clamp(x * size.x, 6f, size.x - 6f),
            Mathf.Clamp(y * size.y, 6f, size.y - 6f));
        marker.localRotation = Quaternion.Euler(0f, 0f, target.eulerAngles.z);
    }
}
