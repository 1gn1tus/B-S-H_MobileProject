using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using UnityEngine;

public class VirtualJoystick : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{
    private Image BgImage;
    private Image joystickImg;
    public Vector3 inputDir;

    private void Start()
    {
        BgImage = GetComponent<Image>();
        joystickImg = transform.GetChild(0).GetComponent<Image>();
        inputDir = Vector3.zero;

    }
    public void OnDrag(PointerEventData pointerEventData)
    {
        Vector2 pos = Vector2.zero;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(BgImage.rectTransform,pointerEventData.position,pointerEventData.pressEventCamera,out pos))
        {
            pos.x = (pos.x / BgImage.rectTransform.sizeDelta.x);
            pos.y = (pos.y / BgImage.rectTransform.sizeDelta.y);
            float x = (BgImage.rectTransform.pivot.x == 1) ? pos.x * 2 + 1 : pos.x * 2 - 1;
            float y = (BgImage.rectTransform.pivot.y == 1) ? pos.y * 2 + 1 : pos.y * 2 - 1;
            inputDir = new Vector3(x, 0, y);
            inputDir = (inputDir.magnitude > 1) ? inputDir.normalized : inputDir;

            joystickImg.rectTransform.anchoredPosition = new Vector3(inputDir.x * (BgImage.rectTransform.sizeDelta.x / 3), inputDir.z * (BgImage.rectTransform.sizeDelta.y / 3));
        }
    }

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        OnDrag(pointerEventData);
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        inputDir = Vector3.zero;
        joystickImg.rectTransform.anchoredPosition = Vector3.zero;
    }
}
