using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UISafeArea : MonoBehaviour
{
    RectTransform canvasRect;


    RectTransform rectTransform;
    Rect safeAreaRect;

    Vector2 minAnchor;
    Vector2 maxAnchor;

    void Start()
    {
        SafeAreaNew();
    }

    private void SafeAreaOld()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasRect = transform.parent.GetComponent<RectTransform>();

        float widthRatio = canvasRect.rect.width / Screen.width;
        float heightRatio = canvasRect.rect.width / Screen.width;

        float offsetTop = (Screen.safeArea.yMax - Screen.height) * heightRatio;
        float offsetBot = Screen.safeArea.yMin * heightRatio;
        float offsetLeft = Screen.safeArea.xMin * widthRatio;
        float offsetRight = (Screen.safeArea.xMax - Screen.width) * widthRatio;

        rectTransform.offsetMax = new Vector2(offsetRight, offsetTop);
        rectTransform.offsetMin = new Vector2(offsetLeft, offsetBot);

        CanvasScaler canvasScaler = canvasRect.GetComponent<CanvasScaler>();
        canvasScaler.referenceResolution = new Vector2(canvasScaler.referenceResolution.x, canvasScaler.referenceResolution.y + Mathf.Abs(offsetTop) + Mathf.Abs(offsetBot));
    }

    private void SafeAreaNew()
    {
        rectTransform = GetComponent<RectTransform>();
        safeAreaRect = Screen.safeArea;

        minAnchor = safeAreaRect.position;
        maxAnchor = minAnchor + safeAreaRect.size;

        minAnchor.x /= Screen.width;
        maxAnchor.x /= Screen.width;
        minAnchor.y /= Screen.height;
        maxAnchor.y /= Screen.height;

        rectTransform.anchorMin = minAnchor;
        rectTransform.anchorMax = maxAnchor;
    }
}
