using HahnTest.Server.Entities;
using HahnTest.Server.Helpers;
using HahnTest.Server.Interfaces;
using System.Data;

namespace HahnTest.Server.Repositories
{
    /// <summary>
    /// due the excersice i used XML to store and save data 
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly UtilitiesHelper _utilitiesHelper;
        private static readonly object FileLock = new object();

        public string DataLocation
        {
            get
            {
                return $"{_utilitiesHelper.BaseLocation}\\MockData\\MockData.xml";
            }
        }

        public EmployeeRepository(UtilitiesHelper utilitiesHelper)
        {
            _utilitiesHelper = utilitiesHelper;
        }
        public List<Employee> GetEmployees()
        {
            lock (FileLock)
            {
                DataTable dt = new DataTable();

                dt.ReadXml(this.DataLocation);

                var employees = new List<Employee>();

                foreach (DataRow row in dt.Rows)
                {
                    employees.Add(new Employee
                    {
                        Id = row["Id"].ToString(),
                        Name = row["Name"].ToString(),
                        Position = row["Position"].ToString(),
                        Salary = Convert.ToDecimal(row["Salary"])
                    });
                }

                return employees;
            }
        }

        public Employee GetEmployeeById(string id)
        {
            var employees = GetEmployees();
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public void Insert(Employee newEmployee)
        {
            lock (FileLock)
            {
                DataTable dt = new DataTable("MockData");

                dt.ReadXml(this.DataLocation);

                DataRow newRow = dt.NewRow();
                newRow["Id"] = newEmployee.Id;
                newRow["Name"] = newEmployee.Name;
                newRow["Position"] = newEmployee.Position;
                newRow["Salary"] = newEmployee.Salary;
                dt.Rows.Add(newRow);

                dt.WriteXml(this.DataLocation,XmlWriteMode.WriteSchema);
            }
        }

        public void Update(Employee updatedEmployee)
        {
            lock (FileLock)
            {
                DataTable dt = new DataTable();

                dt.ReadXml(this.DataLocation);

                DataRow[] rows = dt.Select($"id = '{updatedEmployee.Id}'");
                if (rows.Length > 0)
                {
                    // Update fields
                    rows[0]["Name"] = updatedEmployee.Name;
                    rows[0]["Position"] = updatedEmployee.Position;
                    rows[0]["Salary"] = updatedEmployee.Salary;

                    dt.WriteXml(this.DataLocation, XmlWriteMode.WriteSchema);

                }
                else
                {
                    throw new Exception("Employee doesnt exist");
                }
            }
        }

        public void DeleteEmployee(string id)
        {
            lock (FileLock)
            {
                DataTable dt = new DataTable();
                dt.ReadXml(this.DataLocation);

                DataRow[] rows = dt.Select($"Id = '{id}'");
                if (rows.Length > 0)
                {
                    dt.Rows.Remove(rows[0]);

                    dt.WriteXml(this.DataLocation, XmlWriteMode.WriteSchema);
                }
                else
                {
                    throw new Exception("Employee doesnt exist");
                }
            }
        }
    }
}
