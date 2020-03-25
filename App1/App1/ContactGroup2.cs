using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using static App1.Class1;

namespace App1
{
    class ContactGroup2 : ObservableCollection<Regessery>
    {
        public string title { get; set; }
        public ContactGroup2(string title)
        {
            this.title = title;
        }
    }
}
