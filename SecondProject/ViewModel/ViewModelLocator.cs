/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:SecondProject"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using BookLibrary;
using BookLibrary.Servic;
using BookLibrary.Services;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace SecondProject.ViewModel
{

    public class ViewModelLocator
    {
     
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);



            SimpleIoc.Default.Register<ItemCollection>();
            SimpleIoc.Default.Register<IDataServiceFilter>(() => SimpleIoc.Default.GetInstance<ItemCollection>());
            SimpleIoc.Default.Register<IDataServicEditItem>(() => SimpleIoc.Default.GetInstance<ItemCollection>());


            SimpleIoc.Default.Register<IDataServiceBook, ItemCollectionBook>();
            SimpleIoc.Default.Register<IDataServiceJournal, ItemCollectionJournal>();

            SimpleIoc.Default.Register<TextBoxViewModel>();
            SimpleIoc.Default.Register<ListViewModel>();
            SimpleIoc.Default.Register<FilterViewModel>();
        }

        public TextBoxViewModel TextBox => ServiceLocator.Current.GetInstance<TextBoxViewModel>();
        public ListViewModel ListView => ServiceLocator.Current.GetInstance<ListViewModel>();
        public FilterViewModel Filter => ServiceLocator.Current.GetInstance<FilterViewModel>();

    }
}