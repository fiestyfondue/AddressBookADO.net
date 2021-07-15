using System;

namespace AddressBookADO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Address Book Problem Statement in ADO.Net");
            AddressBookManage addressBookManage = new AddressBookManage();
            

            //addressBookManage.DataBaseConnection(); //UC1
            //Console.ReadLine();



            AddressBook contact = new AddressBook
            {
                firstName = "John",
                lastName = "Cena",
                address = "Hollywood",
                city = "LA",
                state = "Michigan",
                zipcode = 244343,
                phoneNumber = 9898933233,
                email = "UcantSeeMe@email.com",
                Name ="Oliver",
                TypeOf="Friend",
                TYPE="Friend"
            };
            string res = contact.AddContact(contact) ? "Contact added successfull" : "Contact Add failed";  //?-if and :-else
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
