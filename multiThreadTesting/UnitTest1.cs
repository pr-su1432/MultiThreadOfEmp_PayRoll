using MultiThreadOfEmp_PayRoll;

namespace multiThreadTesting
{
    public class Tests
    {


        [Test]
        public void GivenListOfMultipleEmployee_AddToPayrollDataBase_TestTimeWithAndWithout_MutltiThreading()
        {
            List<EmployeeModalClass> modal = new List<EmployeeModalClass>();
            modal.Add(new EmployeeModalClass(ID: 14, NAME: "PRASANNA", SALARY: 30000, START: DateTime.Now, gender: "F", PHONENO: 9703088064, ADDRESS: "KADAPA", DEPARTMENT: "ENGINEER", BASIC_PAY: 25000, DEDUCTIONS: 1300, TAXCABLE_PAY: 1000, NET_PAY: 22800));
            modal.Add(new EmployeeModalClass(ID: 15, NAME: "KATHI", SALARY: 33000, START: DateTime.Now, gender: "F", PHONENO: 9182147305, ADDRESS: "KARNOOL", DEPARTMENT: "SOFTWARE", BASIC_PAY: 33000, DEDUCTIONS: 1500,  TAXCABLE_PAY: 1100, NET_PAY: 30400));
            modal.Add(new EmployeeModalClass(ID: 16, NAME: "ARJUN", SALARY: 45000, START: DateTime.Now, gender: "M", PHONENO: 6005526294, ADDRESS: "CHITTOR", DEPARTMENT: "ARMY", BASIC_PAY: 20000, DEDUCTIONS: 2000, TAXCABLE_PAY: 1200, NET_PAY: 37100));
            modal.Add(new EmployeeModalClass(ID: 17, NAME: "CHITTI", SALARY: 45000, START: DateTime.Now, gender: "F", PHONENO: 6666754325, ADDRESS: "CHITWEL", DEPARTMENT: "MARKETNG", BASIC_PAY: 45000, DEDUCTIONS: 1900, TAXCABLE_PAY: 1300, NET_PAY: 41800));
            modal.Add(new EmployeeModalClass(ID: 17, NAME: "SISI", SALARY: 33000, START: DateTime.Now, gender: "F", PHONENO: 9876543212, ADDRESS: "VONTIMITTA", DEPARTMENT: "SALES", BASIC_PAY: 33000, DEDUCTIONS: 1600, TAXCABLE_PAY: 1100,NET_PAY: 30800));

            EmployeePayRoll payroll = new EmployeePayRoll();
            DateTime start = DateTime.Now;
            payroll.AddNewEmployeeToPayRoll(modal);
            DateTime endTime = DateTime.Now;
            Console.WriteLine("Time required to add multiple employees without using Thread: " + (endTime - start));

            DateTime startThread = DateTime.Now;
            payroll.AddNewEmployeeUsingMultiThread(modal);
            DateTime endThread = DateTime.Now;
            Console.WriteLine("Time required to add multiple employees using thread: " + (endThread - startThread));
        }
    }
}