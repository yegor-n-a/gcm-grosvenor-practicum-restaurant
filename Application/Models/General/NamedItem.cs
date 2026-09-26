using Application.Interfaces.General;

namespace Application.Models.General
{
    public class NamedItem<T> : INamedItem<T>
    {
        public virtual T Name { get; set; }
    }
}
