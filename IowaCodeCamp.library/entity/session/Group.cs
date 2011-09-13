using System.Collections.Generic;

namespace IowaCodeCamp.library.entity.session
{
    public class Group<T> : IEnumerable<T>
    {
        public string FormattedTitle { get { return " " + Title; } }
        public string Title { get; set; }
        public IList<T> Items { get; set; }

        public Group(string name, IEnumerable<T> items)
        {
            Title = name;
            Items = new List<T>(items);
        }

        public override bool Equals(object obj)
        {
            var that = obj as Group<T>;

            return (that != null) && (this.Title.Equals(that.Title));
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }
}
