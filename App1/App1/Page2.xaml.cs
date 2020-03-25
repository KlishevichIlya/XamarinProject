using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static App1.Class1;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using static App1.Regessery;
using Newtonsoft.Json;
using System.IO;

namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page2 : ContentPage
	{
        internal static ObservableCollection<ContactGroup2> regesserys;
        public Page2 ()
		{
			InitializeComponent ();
            var Bondarchyk = new Regessery
            {
                name = "Фёдор Бондарчук",
                films = "9 Рота ",
                age = "55",
                medals = "Оскар",
                imageURL="FEdoR.png"

            };





            /*
            string jsonWorker = JsonConvert.SerializeObject(Bondarchyk);
            var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Setting.txt");
            using (var reader = new StreamReader(backingFile, true))
            {
                string line;
                line = reader.ReadLine();
            }*/
            



           /*   File.WriteAllText(@"C:\Users\Ilya\source\repos\App1\App1\App1.Android\Resources\drawable\movie.json", JsonConvert.SerializeObject(Bondarchyk));
                using (StreamWriter file = File.CreateText(@"C:\Users\Ilya\source\repos\App1\App1\App1.Android\Resources\drawable\movie.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, Bondarchyk);
                }*/
                /*
                  Regessery movie1 = JsonConvert.DeserializeObject<Regessery>(File.ReadAllText(@"c:\movie.json"));
                  using (StreamReader file = File.OpenText(@"C:\Users\Ilya\source\repos\App1\App1\App1.Android\Resources\drawable\movie.json"))
                  {
                      JsonSerializer serializer = new JsonSerializer();
                      Regessery movie2 = (Regessery)serializer.Deserialize(file, typeof(Regessery));
                  }*/


            regesserys = new ObservableCollection<ContactGroup2>
            {
                 new ContactGroup2("А")
                {

                     new Regessery{name="Имя: Алексей Балабанов",films = "Фильмография: Брат(1-2), Война, Жмурки ",age="Возраст: 54(1959-2013)", medals ="Награды: Кинотавр, Ника,Золотой Овен ", imageURL = "blabla.png", infa="Выдающийся советский и российский кинорежиссёр, сценарист и продюсер. Обладатель премии «Ника» за режиссёрскую работу в картине «Про уродов и людей», двукратный призёр кинофестиваля «Кинотавр» за картины «Брат» и «Война».Умер в 2013 году от сердечного приступа. "}

                },
                     new ContactGroup2("Д")
                {
                    new Regessery{name="Имя: Джеймс Ван",films = "Фильмография: Астрал(1-4),Пила(1-6),Форсаж 7",age="Возраст: 41", medals ="Награды: Сатурн", imageURL = "gg2.png",infa="Знаменитый австралийский режиссер, чье имя всемирно известно в связи с культовым фильмом ужасов «Пила». Над разными частями этого триллера Джеймс Ван работал как режиссер, продюсер или сценарист. Другими знаменитыми его работами стали хоррор-франшизы «Астрал» и «Заклятие» вместе со спин-оффом «Проклятие Аннабель».Работал также над фильмом «Форсаж 7»." }
                },
                  new ContactGroup2("Ф")
                {
                    new Regessery{name="Имя: Фёдор Бондарчук",films = "Фильмография: Лёд, 9 рота, Адмиралъ ",age="Возраст: 51", medals ="Награды: Золотой орёл, премия ТЭФИ, Кинотавр", imageURL = "FEdoR.png",infa="Выдающийся советский и российский киноактёр, российский клипмейкер, продюсер кино и телевидения, кинорежиссёр, телеведущий, председатель совета директоров ОАО «Ленфильм».Один из инициаторов проекта «Киносити». Основатель кинокомпании «Art Pictures Studio». " },
                    new Regessery{name="Имя: Фрэнк Дарабонт",films = "Фильмография: Побег из Шоушенка,Зелёная миля,Мгла",age="Возраст: 59", medals ="Награды: Оскар(4 номинации), Сатурн", imageURL = "FranK.png",infa="Знаменитый американский кинорежиссёр, сценарист и продюсер венгерского происхождения. Был трижды номинирован на «Оскар». Известен своими удачными экранизациями романов Стивена Кинга: «Побег из Шоушенка», «Зелёная миля», «Мгла» и другие. " }
                }
                                 
                              };
            //  string json = JsonConvert.SerializeObject(regesserys, Formatting.Indented);
            //string json = JsonConvert.SerializeObject(regesserys);


            listView2.ItemsSource = regesserys;
            listView2.ItemSelected += OnStaffSelected2;
        }
        private async void Delete2_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Regessery;
            var response = await DisplayAlert("Внимание!", "Вы уверены?", "Да", "Нет");
            if (response)
            {
                foreach (var list in regesserys)
                {
                    list.Remove(contact);
                }
            }
        }

        public async void OnStaffSelected2(object sender, SelectedItemChangedEventArgs args)
        {
            // Получаем выбранный элемент 
            Regessery selectedFilm2 = args.SelectedItem as Regessery;
            if (selectedFilm2 != null)
            {
                // Снимаем выделение 
                // Переходим на страницу редактирования элемента 
                await Navigation.PushAsync(new Page3(selectedFilm2));
            }
        }






        private void SearchBar2_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s = e.NewTextValue.ToUpper();
            if (String.IsNullOrEmpty(s))
                listView2.ItemsSource = regesserys;
            else
            {
                var temp = new List<ContactGroup2>();
                foreach (var list in regesserys)
                {
                    if (s.StartsWith(list.title))
                    {
                        var tmp = new ContactGroup2(list.title);
                        foreach (var collection in list)
                        {
                            if (collection.name.ToUpper().StartsWith(s))
                                tmp.Add(collection);
                        }
                        temp.Add(tmp);

                    }
                }
                listView2.ItemsSource = temp;
            }
        }
        private void listView2_Refreshing(object sender, EventArgs e)
        {
            listView2.ItemsSource = regesserys;
            listView2.EndRefresh();
        }
        private void listView2_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }
        private async void More2_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page3());
        }
    }
}