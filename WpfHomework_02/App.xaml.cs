using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Ninject;
using WpfHomework_02.Moduls;
using WpfHomework_02.ViewModels;

namespace WpfHomework_02
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel kernel;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureKernal();
            ComposeObjects();       
            Current.MainWindow.Show();
        }
        private void ConfigureKernal()
        {
            this.kernel = new StandardKernel(new MyModule());
        }
        private void ComposeObjects()
        {
            Current.MainWindow = this.kernel.Get<MainWindow>();
        }
    }
}
