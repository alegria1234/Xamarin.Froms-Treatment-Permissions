using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Froms.Treatment.Permissions.Class;
using Xamarin.Froms.Treatment.Permissions.Enus;

namespace Xamarin.Froms.Treatment.Permissions
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnCamera_Clicked(object sender, EventArgs e)
        {
            Permission.Execute(EPermission.Camera,
                actionAllowed: () =>
                {
                    Console.WriteLine("Enabled Camera");
                },
                actionDenied: () =>
                 {
                     Console.WriteLine("Deny Camera");
                 });
        }

        private void BtnWrite_Clicked(object sender, EventArgs e)
        {
            Permission.Execute(EPermission.WriteExternalStorage,
              actionAllowed: () =>
              {
                  Console.WriteLine("Enabled Write External Storage");
              },
              actionDenied: () =>
              {
                  Console.WriteLine("Deny Write External Storage");
              });
        }

        private void BtnAccess_Clicked(object sender, EventArgs e)
        {
            Permission.Execute(EPermission.AccessFineLocation,
              actionAllowed: () =>
              {
                  Console.WriteLine("Enabled Access Fine Location");
              },
              actionDenied: () =>
              {
                  Console.WriteLine("Deny Access Fine Location");
              });
        }
    }
}
