using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AharHighLevel.ViewModel
{
    public class FormVM
    {
        private static int _idCount;

        public FormVM()
        {
            Id = _idCount++;
            Tags = string.Empty;
        }

        public FormVM(string title, string name, Type content, string tags = "")
        {
            Id = _idCount++;
            Name = name;
            Title = title;
            Content = content;
            Tags = tags;
        }

        public int Id { get; private set; }
        public string Title { get; set; }
        public Type Content { get; set; }
        public  string Name { get; set; }
        public string Tags { get; set; }
    }
}
