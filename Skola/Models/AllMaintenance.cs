using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Skola.Models
{
    internal class AllMaintenance
    {
        public ObservableCollection<Employee> Maintenance { get; set; } = new ObservableCollection<Employee>();

        public AllMaintenance() =>
            LoadMaintenances();

        public void LoadMaintenances()
        {
            Maintenance.Clear();

            string appDataPath = FileSystem.AppDataDirectory;

            IEnumerable<Employee> maintenances = Directory

                                        .EnumerateFiles(appDataPath, "*.maintenances.txt")

                                        .Select(filename => new Employee()
                                        {
                                            Filename = filename,
                                            Name = File.ReadAllText(filename)
                                        })

                                        .OrderBy(maintenance => maintenance.Name);

            foreach (Employee maintenance in maintenances)
                Maintenance.Add(maintenance);
        }
    }
}
