using System;

namespace Menu
{
    public class MenuItem
    {
        public string Name { get; set; }
        public Action<object> Function { get; set; }
        public Func<object, bool> BoolFunction { get; set; }
        public bool IsSelected { get; set; }
        public object Parameter { get; set; }
        public int Distance { get; set; }
        public bool Unselectable { get => unselectable != true ? false : true; set => unselectable = value; }
        private bool unselectable;


        public void Invoke(object parameter = null)
        {
            if (!(Parameter is null))
            {
                parameter = Parameter;
            }
            Function.Invoke(parameter);
        }

    }
}