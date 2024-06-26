using UnityEngine;

public class Parents : MonoBehaviour
{
    [SerializeField] Animator[] anims;
    [SerializeField] Outline[] outlines;
    public bool IsSelected;

    private void OnMouseDown()
    {
        if (IsSelected)
        {
            IsSelected = false;
            foreach (var outline in outlines)
            {
                outline.enabled = false;
            }
        }
        else
        {
            IsSelected = true;
            foreach (var outline in outlines)
            {
                outline.enabled = true;
            }
        }
    }

}
