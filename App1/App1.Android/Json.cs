using System;
using System.IO;
using Xamarin.Forms;
using App1.Droid;

[assembly: Dependency(typeof(Json))]
namespace App1.Droid
{
    class Json:IJson
    {
        public Json() { }
        public string GetDatabasePath(string sqliteFilename)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            return path;
        }
    }
}