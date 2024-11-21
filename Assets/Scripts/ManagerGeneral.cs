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
    LeanTweenType animCurveCircle;
    [SerializeField]
    GameObject popupMenu;
    [SerializeField]
    GameObject popupObjects;
    [SerializeField]
    GameObject popupMenuShowButton;
    [SerializeField]
    GameObject popupMenuHideButton;
    [SerializeField]
    GameObject circle;
    float durationAnim = 0.25f;
    float menuFinalYPositionOnShow = 110f;
    float menuFinalYPositionOnHide = -67f;
    float menuFinalXPosition = -925f;
    float objectsFinalXPositionOnShow = 825f;
    float objectsFinalXPositionOnHide = 1075f;
    public ObjectMover objectMover;
    public ObjectRotator objectRotator;
    public ObjectScalator objectScalator;
    public ObjectDeleter objectDeleter;

    private void Start()
    {
        LeanTween.scaleX(circle, 5f, 1f).setEase(animCurveCircle).setOnComplete(TweenFinished).setLoopPingPong();
        LeanTween.scaleZ(circle, 5f, 1f).setEase(animCurveCircle).setOnComplete(TweenFinished).setLoopPingPong();
    }

    private void TweenFinished()
    {
        LeanTween.scaleX(circle, -4f, 1f).setEase(animCurveCircle);
        LeanTween.scaleZ(circle, -4f, 1f).setEase(animCurveCircle);
    }
    public void MenuPopupActivation()
    {
        popupMenu.SetActive(true);
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

    public void MoveButton()
    {
        MenusDeactivation();
        objectMover.tryingToMoveObject = true;
    }

    public void RotateButton()
    {
        MenusDeactivation();
        objectRotator.tryingToRotateObject = true;
    }

    public void ScaleButton()
    {
        MenusDeactivation();
        objectScalator.tryingToScalateObject = true;
    }

    public void DeleteButton()
    {
        MenusDeactivation();
        objectDeleter.tryingToDeleteObject = true;
    }

    public void MenusDeactivation()
    {
        LeanTween.moveLocalX(popupObjects, objectsFinalXPositionOnHide, durationAnim).setEase(animCurve);
        MenuPopupDeactivation();
        popupMenu.SetActive(false);
    }
}
