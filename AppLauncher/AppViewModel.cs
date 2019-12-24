using System.Collections.Generic;

namespace AppLauncher
{
    public class AppViewModel
    {
        public SortedDictionary<string, string> AppsDictionary { get; set; }

        public List<string> AppNamesCollection
        {
            get
            {
                return new List<string>(AppsDictionary.Keys);
            }
        }

        public AppViewModel(IDictionary<string, string> dictionary)
        {
            AppsDictionary = new SortedDictionary<string, string>(dictionary);
        }
    }
}
