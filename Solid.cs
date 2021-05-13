namespace Beforesrp
{
class Customer
    {
        public void Add()
        {
            try
            {
                // Code
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText(@"c:\Error.txt", ex.ToString());
            }
        }
    }
}
    
//// Applying SRP

namespace Aftersrp
{
    class FileLogger
    {
        public void Handle(string error)
        {
            System.IO.File.WriteAllText(@"c:\Error.txt", error);
        }
    }
    
    class Customer
    {
        private FileLogger obj = new FileLogger();
        public virtual void Add()
        {
            try
            {
                // Code
            }
            catch (Exception ex)
            {
                obj.Handle(ex.ToString());
            }
        }
    
    }
 }
 
 namespace BeforeOpeness 
 {
   class Customer
   {
        private int _CustType;
        public int CustType
        {
            get { return _CustType; }
            set { _CustType = value; }
        }
        
        public double getDiscount(double TotalSales)
        {
                if (_CustType == 1)
                {
                    return TotalSales - 100;
                }
                else
                {
                    return TotalSales - 50;
                }
        }
    }
  }
  
  //// Applying Open-closed principle , instead of doing modification we go for extension
 
namespace afteropenness 
 {
   class Customer
   {
         public virtual double getDiscount(double TotalSales)
        {
            return TotalSales;
        }
    }   
   class SilverCustomer : Customer
    {
        public override double getDiscount(double TotalSales)
        {
            return base.getDiscount(TotalSales) - 50;
        }
    }
    
   class GoldCustomer : Customer
    {
        public override double getDiscount(double TotalSales)
        {
            return base.getDiscount(TotalSales) - 100;
        }
    }    
  }
   
  // beforeliskov
  
  class Enquiry : Customer
    {
        public override double getDiscount(double TotalSales)
        {
            return base.getDiscount(TotalSales) - 5;
        }

        public override void Add()
        {
            throw new Exception("Not allowed");
        }
    }
    
 //// Customer cannot be used as enquiry
 
 class ParentChildError
 {
    List<Customer> Customers = new List<Customer>();
    Customers.Add(new SilverCustomer());
    Customers.Add(new goldCustomer());
    Customers.Add(new Enquiry());

    foreach (Customer o in Customers)
     {
         o.Add();
     }
  }
    
  //// Applying liskov's substitution Principle after creating seperate interfaces for seprate functionality 
  
      interface IDiscount
    {
            double getDiscount(double TotalSales);
    }


    interface IDatabase
    {
            void Add();
    }
    
    class Enquiry : IDiscount
    {
        public  double getDiscount(double TotalSales)
        {
            return TotalSales - 5;
        }
    }
    
   class Customer : IDiscount, IDatabase
   {


       private MyException obj = new MyException();
       public virtual void Add()
       {
           try
           {
               // Database code goes here
           }
           catch (Exception ex)
           {
               obj.Handle(ex.Message.ToString());
           }
       }

       public virtual double getDiscount(double TotalSales)
       {
           return TotalSales;
       }
   }
   
 class ParentChildOk
 {
    List<IDatabase> Customers = new List<IDatabase>();
    Customers.Add(new SilverCustomer());
    Customers.Add(new goldCustomer());
    Customers.Add(new Enquiry());

    foreach (IDatabase o in Customers)
     {
         o.Add();
     }
  }
   
  interface IDatabase
{
        void Add(); // old client are happy with these.
voidRead(); // Added for new clients.
}

// segregating interfaces to accomodate new clients requirements.

interface IDatabaseV1 : IDatabase // Gets the Add method
{
Void Read();
}

    class CustomerwithRead : IDatabase, IDatabaseV1
        {

    public void Add()
    {
      Customer obj = new Customer();
    Obj.Add();
    }
      Public void Read()
      {
      // Implements  logic for read
    }
    }
class methodsobjcreation
{
    IDatabase i = new Customer(); // 1000 happy old clients not touched
    i.Add();

    IDatabaseV1 iv1 = new CustomerWithread(); // new clients
    Iv1.Read();
}

// Dependency Inversion Principle to invert the dependent object creation to a seperate client who will pass the interface to the constructor of the Customer Class.

class Customer : IDiscount, IDatabase
 {
        private Ilogger obj;
        public Customer(ILogger i)
        {
            obj = i;
        }
}
}
   
   
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
