using System;

namespace ObservableCollection_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Collections.ObjectModel.ObservableCollection<DataBase> dataBases = new System.Collections.ObjectModel.ObservableCollection<DataBase>();

            dataBases.CollectionChanged += ChangingDataBase_Log;
            dataBases.CollectionChanged += ChangingDataBase_Write; ;

            dataBases.Add(new DataBase { UserFUllName = "s", Id = 1 });
            dataBases.Add(new DataBase { UserFUllName = "ss", Id = 2 });
            dataBases.Remove(new DataBase { UserFUllName = "s", Id = 1 });
            dataBases.Add(new DataBase { UserFUllName = "sss", Id = 3 });
            dataBases.Add(new DataBase { UserFUllName = "ssss", Id = 4 });
            dataBases.RemoveAt(2);

            Console.ReadKey();

        }

        private static void ChangingDataBase_Write(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                foreach (DataBase item in e.NewItems)
                    Console.WriteLine($" Name = {item.UserFUllName} \n ID = {item.Id}");
        }

        private static void ChangingDataBase_Log(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n-----------------------------------------------------------------------------------\n" + "Log ===> New Data Added To DataBase In " + DateTime.Now);
            }
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n-----------------------------------------------------------------------------------\n" + "Log ===> Data Removed Sinse DataBase In " + DateTime.Now);
            }
        }
    }

    public struct DataBase
    {
        public long Id { get; set; }
        public string UserFUllName { get; set; }

    }
}
