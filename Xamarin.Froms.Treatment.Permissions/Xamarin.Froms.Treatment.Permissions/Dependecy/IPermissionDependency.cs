using Xamarin.Froms.Treatment.Permissions.Enus;

namespace Xamarin.Froms.Treatment.Permissions.Interfaces
{
    public interface IPermissionDependency
    {
        OnPermissionRequestDelegate OnPermissionRequest { get; set; }
        bool CheckPermission(EPermission permission);
        void RequestPermission(EPermission permission);
    }

    public delegate void OnPermissionRequestDelegate(EPermission permission, bool allowed);
}
