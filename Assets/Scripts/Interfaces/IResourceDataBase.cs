namespace Assets.Scripts.Interfaces
{
    public interface IResourceDatabase
    {
        void RegisterFoundResource(IResource resource);
        bool TryGetUnreservedResource(out IResource resource);
        void UnreserveResource(IResource resource);
    }
}
