using System;
namespace RimWorldModListing.Utilities
{
    public struct ModMeta
    {
        public string id;
        public string path;
        public string name;
        public string author;
        public string workshop;

    public ModMeta(string i, string p, string n, string a, string w)
        {
            id = i;
            path = p;
            name = n;
            author = a;
            workshop = w;
        }
    }
}
