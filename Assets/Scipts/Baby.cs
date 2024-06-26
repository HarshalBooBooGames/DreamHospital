using UnityEngine;

public class Baby : MonoBehaviour
{
    [SerializeField] Outline outline;
    [SerializeField] Animator anim;

    public bool isSelected;

    private void OnMouseDown()
    {
        if (isSelected)
        {
            isSelected = false;
            outline.enabled = false;
        }
        else
        {
            isSelected = true;
            outline.enabled = true;
        }
    }
}
