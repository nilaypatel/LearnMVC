using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace LearnCastleWindsor
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ioc = IocContainer.Initialize();

            //var reportJobData = new ReportJobData() {JobGroup = "Report", Name = "SalesReportJob", Note = "abc"};

            //var jobData = (IJobData) reportJobData;

            //var castedReportData = (IReportJobData) jobData;

            //Console.WriteLine(castedReportData.JobGroup);

            //Console.ReadLine();

            SendEmailAsync();

            Console.WriteLine("Executing further steps.....");

            Console.WriteLine("waiting...........................");

            Console.ReadLine();
        }

        static async void SendEmailAsync()
        {
            try
            {
                Console.WriteLine("send email async started");

                await SendEmail();

                Console.WriteLine("send email async completed");
            }
            catch (Exception)
            {
                Console.WriteLine("Exception from send eamil....");
            }
        }

        static async Task SendEmail()
        {
            Console.WriteLine("waiting for 2 seconds");
            await Task.Delay(2000);
            Console.WriteLine("waiting for 2 seconds");
            throw new Exception();
            //return new SmtpClient().SendMailAsync("from@abc.com", "to@abc.com", "subject", "body");
        }
    }
}

public interface IJobData
{
    string Name { get; set; }

    string Note { get; set; }
}

public class JobData : IJobData
{
    public string Name { get; set; }
    public string Note { get; set; }
}

public interface IReportJobData : IJobData
{
    string JobGroup { get; set; }
}

public class ReportJobData : IReportJobData
{
    public string Name { get; set; }
    public string Note { get; set; }
    public string JobGroup { get; set; }
}


/*
     var employeeService = ioc.Resolve<IEmployeeService>();
            //employeeService.AddEmployee();


            var instance = IocContainer.Instance;

            var container = instance.Container;
            container.Dispose();

    internal interface IEmployeeService
    {
        int AddEmployee();
    }

    public class EmployeeService : IEmployeeService
    {
        public int AddEmployee()
        {
            throw new NotImplementedException();
        }
    } */
