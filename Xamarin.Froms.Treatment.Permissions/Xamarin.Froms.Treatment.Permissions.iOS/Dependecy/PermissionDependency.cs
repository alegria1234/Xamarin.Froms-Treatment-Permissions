using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Froms.Treatment.Permissions.Enus;
using Xamarin.Froms.Treatment.Permissions.Interfaces;
using Xamarin.Froms.Treatment.Permissions.iOS.Dependecy;

[assembly: Xamarin.Forms.Dependency(typeof(PermissionDependency))]
namespace Xamarin.Froms.Treatment.Permissions.iOS.Dependecy
{
    public class PermissionDependency : IPermissionDependency
    {
        public OnPermissionRequestDelegate OnPermissionRequest { get; set; }

        bool IPermissionDependency.CheckPermission(EPermission permission)
        {
            return true;
        }

        void IPermissionDependency.RequestPermission(EPermission permission)
        {
            OnPermissionRequest?.Invoke(permission, true);
        }
    }
}