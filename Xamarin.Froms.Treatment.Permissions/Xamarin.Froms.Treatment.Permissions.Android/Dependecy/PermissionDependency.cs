using Android;
using Android.Content.PM;
using Android.Support.V4.App;
using Android.Support.V4.Content;   
using System;
using Xamarin.Froms.Treatment.Permissions.Droid.Dependency;
using Xamarin.Froms.Treatment.Permissions.Enus;
using Xamarin.Froms.Treatment.Permissions.Interfaces;
using Android.App;

[assembly: Xamarin.Forms.Dependency(typeof(PermissionDependency))]
namespace Xamarin.Froms.Treatment.Permissions.Droid.Dependency
{
    public class PermissionDependency : IPermissionDependency
    {
        public delegate void OnExecuteResponseRequestPermissionDelegate(string namePermission, bool allowed);
        public static OnExecuteResponseRequestPermissionDelegate OnExecuteResponseRequestPermission { get; set; }
        public OnPermissionRequestDelegate OnPermissionRequest { get; set; }

        public bool CheckPermission(EPermission permission)
        {
            string permissionManifest = GetManifestPermission(permission);

            if (permissionManifest == null)
            {
                return false;
            }

            return ContextCompat.CheckSelfPermission(Application.Context.ApplicationContext, permissionManifest) == (int)Permission.Granted;
        }

        public void RequestPermission(EPermission permission)
        {
            try
            {
                var activity = MainActivity.Instance;
                string permissionManifest = GetManifestPermission(permission);

                if (permissionManifest == null)
                {
                    return;
                }

                ActivityCompat.RequestPermissions(activity, new String[] { permissionManifest }, 1);

                OnExecuteResponseRequestPermission = (namePermission, allowed) =>
                  {
                      if (permissionManifest == namePermission)
                      {
                          OnPermissionRequest?.Invoke(permission, allowed);
                      }
                  };
            }
            catch(Exception)
            { 
            }
        }

        private string GetManifestPermission(EPermission permission)
        {
            switch (permission)
            {
                case EPermission.Camera:
                    return Manifest.Permission.Camera;

                case EPermission.WriteExternalStorage:
                    return Manifest.Permission.WriteExternalStorage;

                case EPermission.AccessFineLocation:
                    return Manifest.Permission.AccessFineLocation;
            }
            return null;
        }
    }
}