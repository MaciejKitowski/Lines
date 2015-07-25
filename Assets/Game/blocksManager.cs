using UnityEngine;
using System.Collections;

public class blocksManager : MonoBehaviour 
{
    public blockController getSelectedBlock()
    {
        foreach (Transform block in transform) if (block.gameObject.GetComponent<blockController>().selected) return block.gameObject.GetComponent<blockController>();
        return null;
    }

    //To use in arenaBlockController
    public bool blockSelected()
    {
        foreach (Transform block in transform) if (block.gameObject.GetComponent<blockController>().selected) return true;
        return false;
    }

    //To use in blockController
    public bool blockIsSelected() 
    {
        foreach(Transform block in transform)
        {
            if (block.gameObject.GetComponent<blockController>().selected)
            {
                block.gameObject.GetComponent<blockController>().selected = false;
                Debug.LogWarning("Multiple selection");
                return true;
            }
        }
        return false;
    }
}
