using System;
using Xamarin.Forms;
using Xamarin.Froms.Treatment.Permissions.Enus;
using Xamarin.Froms.Treatment.Permissions.Interfaces;

namespace Xamarin.Froms.Treatment.Permissions.Class
{
    public class Permission
    {
        public static bool Check(EPermission permission)
        {
            var permissionDependency = DependencyService.Get<IPermissionDependency>();

            if (permissionDependency == null)
            {
                return false;
            }
            return permissionDependency.CheckPermission(permission);
        }

        public static void Execute(EPermission permission, Action actionAllowed, Action actionDenied)
        {
            var permissionDependency = DependencyService.Get<IPermissionDependency>();

            if (permissionDependency == null)
            {
                return;
            }

            if (Check(permission))
            {
                actionAllowed();
            }
            else
            {
                permissionDependency.RequestPermission(permission);
                permissionDependency.OnPermissionRequest = (per, allowed) =>
                {
                    if (allowed)
                    {
                        actionAllowed();
                    }
                    else
                    {
                        actionDenied();
                    }
                };
            }
        }
    }
}
