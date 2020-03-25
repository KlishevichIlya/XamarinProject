using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static App1.Class1;
using System.Xml.Serialization;
using System.IO;
using Newtonsoft.Json;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace App1
{
   
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {

        internal static List<Contact> contacts;
        
        internal static ObservableCollection<ContactGroup> finalList;
      
        internal static string  path;
       

        public Page1()
        {

            InitializeComponent();
          /* var Rota9 = new Contact
            {
                name = "9 Рота",
                kategoriya = "Боевик",
                avtor = "Фёдор Бондарчук",
                age = "29/09/2005",
                imageURL = "rota.png"
            };*/

          



           // listView.ItemsSource = contacts;
            listView.ItemSelected += OnStaffSelected;
        }



        protected override void OnAppearing()
        {
            base.OnAppearing();
           
                /*contacts = new List<Contact>
                   {


                           new Contact{name="Астрал",
                            mark= "Рейтинг: 6.8/10",
                            kategoriya= "Жанр: Ужасы,триллер",
                           avtor= "Режиссер: Джеймс Ван",
                           age= "Дата выхода: 01/04/2011",
                           infa= "Джош и Рене переезжают с детьми в новый дом, но не успевают толком распаковать вещи, как начинаются странные события. Необъяснимо перемещаются предметы, в детской звучат странные звуки... Но настоящий кошмар начинается для родителей, когда их десятилетний сын Далтон впадает в кому. Все усилия врачей в больнице помочь мальчику безуспешны... ",
                           imageURL= "astra.png"},


                             new Contact{name=Resource.Brother,
                             mark= Resource.Reate_9,
                             kategoriya=Resource.Genre_Drama,
                             avtor= Resource.Producer_Alex_Balabanov,
                             age= Resource.Data_realese_19_09_1997,
                             infa= "Демобилизованный из армии, Данила Багров возвратился в родной городок. Но скучная жизнь русской провинции не устраивала его, и он решился податься в Петербург, где, по слухам, уже несколько лет процветает его старший брат. Данила отыскал брата. Но все оказалось не так просто — брат был наемным убийцей... ",
                             imageURL= "bratik.png" },


                          new Contact{name= "Рота 9",
                            mark= "Рейтинг: 7.2/10",
                            kategoriya="Жанр: Боевик,драма",
                            avtor= "Режиссер: Фёдор Бондарчук",
                            age= "Дата выхода: 29/09/2005",
                            infa= "СССР. Действие происходит в 1988 и 1989 годах, за некоторое количество месяцев до полного вывода советских войск из Афганистана. Семеро призывников, после нескольких месяцев адской подготовки в «учебке» под командованием бесжалостного старшины, попадают в горнило афганской кампании.Группа десантников, бойцами которой стали наши герои, получает поручение командования — занять высоту и удерживать ее до прохождения колонны... ",
                            imageURL= "rota.png" },



                           new Contact{
                                name= "Побег из Шоушенка",
                    mark= "Рейтинг: 9.3/10",
                    kategoriya= "Жанр: Драма",
                    avtor= "Режиссер: Фрэнк Дарабонт",
                    age="Дата выхода: 10/09/1994",
                    infa= "Успешный банкир Энди Дюфрейн обвинен в убийстве своей жены и ее любовника. Оказавшись в тюрьме под названием Шоушенк, он встречается с безжалостностью и беззаконием, царящими по обе стороны решетки. Каждый, кто попадает в эти стены, становится их рабом до конца жизни. Но Энди, вооруженный живым умом и доброй душой, отказывается примиряться с приговором судьбы и начинает разрабатывать неописуемо дерзкий план своего освобождения. ",
                    imageURL= "run.png"
                           }


                   };*/
                finalList = new ObservableCollection<ContactGroup>();
                path = DependencyService.Get<IJson>().GetDatabasePath("workers.json");
                {
                     //string jsonoutput = Newtonsoft.Json.JsonConvert.SerializeObject(contacts);
                     //File.WriteAllText(path, jsonoutput);
                }
                contacts = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Contact>>(File.ReadAllText(path));

                string alphabet2 = "АБВГДЕЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯABCDEFGHIJKLMNOPQRSTUVWXYZ";
                Letter[] alph2 = new Letter[58];
                for (int i = 0; i < 58; i++)
                    alph2[i] = new Letter { s = alphabet2.Substring(i, 1), friends = new ContactGroup(alphabet2.Substring(i, 1)) };

                foreach (var elem in contacts)
                {
                    int index;
                    if (elem.name[0] >= 'A' && elem.name[0] <= 'Z')
                        index = (elem.name[0] - 'A') + 32;
                    else
                        index = elem.name[0] - 'А';
                    alph2[index].flag = true;
                    alph2[index].friends.Add(elem);
                }

                foreach (var elem in alph2)
                    if (elem.flag)
                        finalList.Add(elem.friends);


                listView.ItemsSource = finalList;
                

        }
           
            
        



        private async void  Delete_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            var response = await DisplayAlert("Внимание!", "Вы уверены?", "Да", "Нет");
            if(response)
            {
                foreach(var list in finalList)
                {
                    list.Remove(contact);
                }
                contacts.Remove(contact);
                string jsonoutput = Newtonsoft.Json.JsonConvert.SerializeObject(contacts);
                File.WriteAllText(path, jsonoutput);
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string s = e.NewTextValue.ToUpper();
            if (String.IsNullOrEmpty(s))
                listView.ItemsSource = finalList;
            else
            {
                var temp = new List<ContactGroup>();
                foreach(var list in finalList)
                {
                    if(s.StartsWith(list.title))
                    {
                        var tmp = new ContactGroup(list.title);
                        foreach(var collection in list)
                        {
                            if (collection.name.ToUpper().StartsWith(s))
                                tmp.Add(collection);
                        }
                        temp.Add(tmp);

                    }
                }
                listView.ItemsSource = temp;
            }
        }
        public async void OnStaffSelected(object sender, SelectedItemChangedEventArgs args)
        {
            // Получаем выбранный элемент 
            Contact selectedFilm = args.SelectedItem as Contact;
            if (selectedFilm != null)
            {
                // Снимаем выделение 
                // Переходим на страницу редактирования элемента 
                await Navigation.PushAsync(new Page3(selectedFilm));
            }
        }
        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void listView_Refreshing(object sender, EventArgs e)
        {
            listView.ItemsSource = contacts;
            listView.EndRefresh();
        }

        private async void More_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page3());
        }




       


    }
}