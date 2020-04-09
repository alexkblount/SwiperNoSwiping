using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Swiper
{
    public class MainPageViewModel : BaseViewModel
    {
        private ObservableCollection<Person> people;

        public ObservableCollection<Person> People { get => people; set => RaiseAndUpdate(ref people, value); }


        public MainPageViewModel()
        {
            People = new ObservableCollection<Person>();

            People.Add(new Person { Age = 42, Name = "Alex Blount" });
            People.Add(new Person { Age = 54, Name = "David Ortinau" });
            People.Add(new Person { Age = 22, Name = "Miguel De Icaza" });
            People.Add(new Person { Age = 13, Name = "Liberty Blount" });
        }

        public void SwipeEnded(Person swipedPerson)
        {
            People.Remove(swipedPerson);
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
