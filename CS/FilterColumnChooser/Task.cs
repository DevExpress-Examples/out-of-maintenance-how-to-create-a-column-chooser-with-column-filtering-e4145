using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace FilterColumnChooserExample
{
    public class Task
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public bool IsComplete { get; set; }

        public object COl1 { get { return "test #1"; } }
        public object COl2 { get { return "test #2"; } }
        public object COl3 { get { return "test #3"; } }
        public object COl4 { get { return "test #4"; } }
        public object COl5 { get { return "test #5"; } }
        public object COl6 { get { return "test #6"; } }
        public object COl7 { get { return "test #7"; } }

        public static ObservableCollection<Task> GetList {
            get {
                ObservableCollection<Task> collection = new ObservableCollection<Task>();
                for (int i = 0; i < 5; i++) {
                    Random rnd = new Random(i);
                    DateTime _startDate = DateTime.Now.AddDays(i);
                    collection.Add(new Task {
                        Name = "Task " + i,
                        StartDate = _startDate,
                        FinishDate = _startDate.AddDays(rnd.Next(10, 20)),
                        IsComplete = rnd.Next(2) == 0
                    });
                }
                return collection;
            }
        }
    }
}