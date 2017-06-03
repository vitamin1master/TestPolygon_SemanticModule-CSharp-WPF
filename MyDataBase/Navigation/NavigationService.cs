using System;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Documents;

namespace MyDataBase.Navigation
{
    public class NavigationService
    {
        private Page _pageNumber1, _pageNumber2;
        private readonly Frame _frame;

        public NavigationService(Frame frame)
        {
            _frame = frame;
        }

        public void PushPages(Page pageNumber1, Page pageNumber2)
        {
            _pageNumber1 = pageNumber1;
            _pageNumber2 = pageNumber2;
        }

        //public bool Navigate<T>(object parametr = null)
        //{
        //    var type = typeof(T);
        //    return Navigate(type);
        //}

        //public bool Navigate(Type sourceType, object parametr = null)
        //{
        //    var src = Activator.CreateInstance(sourceType);
        //    return _frame.Navigate(src, parametr);
        //    //return frame.Navigate(new System.Uri("InfoPage.xaml", UriKind.RelativeOrAbsolute));

        //}
        //public bool Navigate(string page)
        //{
        //    var sourceType = Assembly.GetExecutingAssembly().GetTypes().SingleOrDefault(a => a.Name.Equals(page));
        //    if (sourceType == null)
        //        return false;
        //    var src = Activator.CreateInstance(sourceType);
        //    return _frame.Navigate(src);
        //}

        public bool Navigate(string namePage)
        {
            if (_pageNumber1.GetType().Name == namePage)
                return _frame.Navigate(_pageNumber1);
            if (_pageNumber2.GetType().Name == namePage)
                return _frame.Navigate(_pageNumber2);
            return false;
        }
        public bool Navigate(Page page)
        {
            return _frame.Navigate(page);
        }
    }
}
