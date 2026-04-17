namespace Practice;

public static class LinqProblems
{
    public static List<int> EvenNumbers(List<int> numbers) => numbers?.Where(x => x % 2 == 0).ToList() ?? new List<int>();

    public static IEnumerable<int> PositiveNumbers(int[] nums) => nums?.Where(x => x > 0) ?? Enumerable.Empty<int>();

    public static IEnumerable<string> StringLengthGreaterThan3(List<string> str) => str?.Where(x => !string.IsNullOrEmpty(x) && x.Length > 3) ?? Enumerable.Empty<string>();

    public static IEnumerable<int> NumberInARange(IEnumerable<int> numbers) => numbers?.Where(x => x >= 10 && x <= 50) ?? Enumerable.Empty<int>();

    public static IEnumerable<string> ExcludeNullAndEmpty(IEnumerable<string> str) => str?.Where(x => !string.IsNullOrWhiteSpace(x)) ?? Enumerable.Empty<string>();

    public static IEnumerable<string> StartWithLetterA(List<string> names) => names?.Where(x => !string.IsNullOrEmpty(x) && x.StartsWith("A", StringComparison.OrdinalIgnoreCase)) ?? Enumerable.Empty<string>();

    public static IEnumerable<int> Adults(List<int> ages) => ages?.Where(x => x > 18) ?? Enumerable.Empty<int>();

    public static IEnumerable<int> ExtractInt(ArrayList mixed) => mixed?.OfType<int>() ?? Enumerable.Empty<int>();

    public static int[] EvenIndices(int[] numbers) => numbers?.Where((value, index) => index % 2 == 0).ToArray() ?? Array.Empty<int>();

    public static List<int> ReturnNonNullValues(List<int?> numbers) => numbers?.Where(x => x.HasValue).Select(x => x!.Value).ToList() ?? new List<int>();

    public static List<int> TransformIntToSquares(List<int> numbers) => numbers?.Select(x => x * x).ToList() ?? new List<int>();

    public static List<string> ProjectToFirstChars(List<string> strings) => strings?.Where(x => !string.IsNullOrEmpty(x)).Select(x => x[..1]).ToList() ?? new List<string>();

    public static List<NewPerson> ProjectToNewPerson(List<Person> persons) => persons?.Select(p => new NewPerson { FullName = $"{p.FirstName} {p.LastName}".Trim(), Age = p.Age }).ToList() ?? new List<NewPerson>();

    public static List<int> FlattenList(List<List<int>> list) => list?.SelectMany(x => x).ToList() ?? new List<int>();

    public static List<Employee> GetAllEmployeesAllDepartments(IEnumerable<Department> departments) => departments?.SelectMany(x => x.Employees).ToList() ?? new List<Employee>();

    public static IEnumerable<Employee> EmployeeEarnings(IEnumerable<Employee> employees) => employees?.Where(x => x.Salary > 100000) ?? Enumerable.Empty<Employee>();

    public static IEnumerable<NamesDto> Names(IEnumerable<Company> companies)
    {
        if (companies == null)
            return Enumerable.Empty<NamesDto>();

        return companies
            .SelectMany(company => company.Departments, (company, department) => new { company, department })
            .SelectMany(x => x.department.Employees, (x, employee) => new NamesDto
            {
                CompanyName = x.company.Name,
                DepartmentName = x.department.Name,
                EmployeeName = employee.Name
            });
    }

    public static List<string> ProduceAllWords(List<string>[] lists) => lists?.SelectMany(x => x).ToList() ?? new List<string>();

    public static List<(int Number, bool IsEven)> ProduceFalseIfOdd(List<int> numbers) => numbers?.Select(x => (x, x % 2 == 0)).ToList() ?? new List<(int, bool)>();

    public class Person
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
    }

    public class NewPerson
    {
        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }
    }

    public class Company
    {
        public string Name { get; set; } = string.Empty;
        public List<Department> Departments { get; set; } = new();
    }

    public class Department
    {
        public string Name { get; set; } = string.Empty;
        public List<Employee> Employees { get; set; } = new();
    }

    public class Employee
    {
        public string Name { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }

    public class NamesDto
    {
        public string CompanyName { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
    }
}
