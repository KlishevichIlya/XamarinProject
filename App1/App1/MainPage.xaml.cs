using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Globalization;


namespace App1
{
    

    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
    }
    public partial class MainPage : MasterDetailPage
    {
       
       /* public interface IFileWorker
        {
            Task<bool> ExistsAsync(string filename); // проверка существования файла
            Task SaveTextAsync(string filename, string text);   // сохранение текста в файл
            Task<string> LoadTextAsync(string filename);  // загрузка текста из файла
            Task<IEnumerable<string>> GetFilesAsync();  // получение файлов из определнного каталога
            Task DeleteAsync(string filename);  // удаление файла
        }*/
        public MainPage()
        {
            InitializeComponent();
             
            Detail = new NavigationPage(new Page1());

            IsPresented = true;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Page2());

            IsPresented = false;
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Page1());

            IsPresented = false;
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Page4());

            IsPresented = false;
        }
        private void Button5_Click(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Page5());

            IsPresented = false;
        }

    }
}
