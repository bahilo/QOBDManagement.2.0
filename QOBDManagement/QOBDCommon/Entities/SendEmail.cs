// FILE: D:/Just IT Training/BillManagment/Classes//SendEmail.cs

// In this section you can add your own using directives
// section -64--88-0-12--65b75d98:1535bf612db:-8000:0000000000000C6B begin
// section -64--88-0-12--65b75d98:1535bf612db:-8000:0000000000000C6B end

using System;
/// <summary>
///  A class that represents ...
/// 
///  @see OtherClasses
///  @author Dago
/// </summary>
namespace QOBDCommon.Entities
{
    public class SendEmail 
    {
        // Attributes

        public Client Client {get; set;}

        public Agent Agent {get; set;}

        public Bill Bill {get; set;}

        public string Message {get; set;}
        
        public void Send()
        {
            throw new NotImplementedException();
        }


        // Operations


    } /* end class SendEmail */
}