using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using static App1.Class1;

namespace App1
{
    class ContactGroup: ObservableCollection<Contact>
    {
        public string title { get; set; }
        public ContactGroup(string title)
        {
            this.title = title;
        }
    }
}
