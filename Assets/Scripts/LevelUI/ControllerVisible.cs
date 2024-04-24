using UnityEngine;

public class ControllerVisible : MonoBehaviour
{
    [SerializeField] private GameObject expertController;
    [SerializeField] private GameObject classicController;

    private void Start()
    {
        if (ControlManager.Instance.IsClassicControl())
        {
            classicController.SetActive(true);
            expertController.SetActive(false);
        }

        if (ControlManager.Instance.IsExpertControl())
        {
            classicController.SetActive(false);
            expertController.SetActive(true);
        }
    }
}
