using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Employee_Payroll_MVCApplication.Startup))]
namespace Employee_Payroll_MVCApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
