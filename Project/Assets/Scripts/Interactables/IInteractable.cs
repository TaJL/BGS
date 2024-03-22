public interface IInteractable
{
    public bool CanBeInteractedWith();
    public void Interact(InteractionHandler interactionHandler);
}
