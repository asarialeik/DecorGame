using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UIElements;

public class ManagerGeneral : MonoBehaviour
{
    [SerializeField]
    LeanTweenType animCurve;
    [SerializeField]
    GameObject popupMenu;
    [SerializeField]
    GameObject popupObjects;
    [SerializeField]
    GameObject popupMenuShowButton;
    [SerializeField]
    GameObject popupMenuHideButton;
    [SerializeField]
    float durationAnim = 0.25f;
    [SerializeField]
    float menuFinalYPositionOnShow = 110f;
    [SerializeField]
    float menuFinalYPositionOnHide = -67f;
    [SerializeField]
    float menuFinalXPosition = -925f;
    [SerializeField]
    float objectsFinalXPositionOnShow = 825f;
    [SerializeField]
    float objectsFinalXPositionOnHide = 0f;

   

    public void MenuPopupActivation()
    {
        popupMenuHideButton.SetActive(true);
        LeanTween.moveLocalY(popupMenu, menuFinalYPositionOnShow, durationAnim).setEase(animCurve);
        popupMenuShowButton.SetActive(false);
    }
    public void MenuPopupDeactivation()
    {
        popupMenuShowButton.SetActive(true);
        LeanTween.moveLocalY(popupMenu, menuFinalYPositionOnHide, durationAnim).setEase(animCurve);
        popupMenuHideButton.SetActive(false);
    }

    public void CreateButton()
    {
        LeanTween.moveLocalX(popupObjects, objectsFinalXPositionOnShow, durationAnim).setEase(animCurve);
        LeanTween.moveLocalX(popupMenu, menuFinalXPosition, durationAnim).setEase(animCurve);
    }

    public void MenusDeactivation()
    {
        LeanTween.moveLocalX(popupObjects, objectsFinalXPositionOnHide, durationAnim).setEase(animCurve);
        MenuPopupDeactivation();
    }
}
