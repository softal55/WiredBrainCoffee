using System.Threading.Channels;
using WiredBrainCoffee.StorageApp.Data;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;


var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext()) ;

AddEmployees(employeeRepository);
AddManagers(employeeRepository);
GetEmpolyeeById(employeeRepository);
WriteAllToConsole(employeeRepository);



static void AddEmployees(IRepository<Employee> employeeRepository)
{
    employeeRepository.Add(new Employee { FirstName = "Yacine" });
    employeeRepository.Add(new Employee { FirstName = "Hicham" });
    employeeRepository.Add(new Employee { FirstName = "Abderrahim" });

    employeeRepository.Save();
}

static void AddManagers(IWriteRepository<Manager> managerRepository)
{
    managerRepository.Add(new Manager { FirstName = "Sofiane" });
    managerRepository.Add(new Manager { FirstName = "Mohammed" });
    managerRepository.Save();
}
void GetEmpolyeeById(IRepository<Employee> employeeRepository)
{
    var employee = employeeRepository.GetById(2);
    Console.WriteLine($"Employee With Id 2 : {employee.FirstName}");
}

var organizationRepository = new ListRepository<Organization>();

AddOrganization(organizationRepository);
WriteAllToConsole(organizationRepository);


static void AddOrganization(IRepository<Organization> organizationRepository)
{
    var organizations = new[]
    {
        new Organization { Name = "Instagram" },
        new Organization { Name = "Facebook" }
    };
    AddBatch(organizationRepository, organizations);
  
}

/// <summry>
/// I didn't understand this issue?
/// </summry>
private static void AddBatch(IRepository<Organization> organizationRepository, Organization[] organizations)
{
    foreach(var item in organizations)
    {
        organizationRepository.Add(item);
    }
    organizationRepository.Save();
}

void WriteAllToConsole(IReadRepository<IEntityBase> repository)
{
    var items = repository.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
}
