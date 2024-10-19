
using Module07DataAccess.ViewModel;
using Module07DataAccess.Services;



namespace Module07DataAccess.View;
public partial class ViewPersonal : ContentPage
{
    public ViewPersonal()
    {
        InitializeComponent();

        var personalViewModel = new PersonalViewModel();
        BindingContext = personalViewModel;
    }
}