using UnityEngine;

public class DialogueSource : MonoBehaviour, IInteractable
{
    public bool CanBeInteractedWith()
    {
        return true;
    }

    public void Interact()
    {
        print(name);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
