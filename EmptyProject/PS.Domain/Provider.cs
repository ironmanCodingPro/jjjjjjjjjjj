using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace PS.Domain
{
    public class Provider : Concept
    {
        [Key]
        public int Id { get; set; }


        String password;   //hedha bch nkhdem bih fi wost l attribut


        [DataType(DataType.Password)]  //pour cryptage
        [MinLength(8)]                 // min carecter 8 inserer
        [Required]
        public String Password
        {
            get { return password; }
            set
            {
                if (value.Length <= 20 && value.Length >= 5)
                {
                    password = value;
                }
                else { System.Console.WriteLine("La taille de PAssword est entre 5 et 20 "); }
            }
        }

        String confirmPassword;

        [Required]

        [NotMapped]
        [Compare("password")]     //pour verfication avec mot de pass cree et non inserer dans la base de donnne
        public String ConfirmPassword { 
            get { return confirmPassword; }
            set{
                if (value == Password)
                {
                    confirmPassword = value;
                    System.Console.WriteLine("Confirm password confirmed ");
                }
                else { System.Console.WriteLine("confirm password est different du password"); }
            }
        }

        public DateTime DateCreated { get; set; }


        [Required]
        [EmailAddress]
        public String Email { get; set; }
        public bool IsApproved { get; set; }

       
        public String UserName { get; set; }

        [NotMapped]   // pou annuler relation manytomany
        public virtual IList<Product> Products { get; set; }

        public override void GetDetails()
        {
            Console.WriteLine("Provider Name: {0}, DateCreated : {1} ", UserName, DateCreated);
            foreach (Product p in Products)
            {
                p.GetDetails();
            }
        }


        public static void SetIsApproved(Provider P)
        {
            P.IsApproved =  P.Password == P.ConfirmPassword;
        }
        public static void  SetIsApproved(string password, string confirmPassword,out bool isApproved)
        {
           isApproved = password == confirmPassword;
        }

        //public bool Login(String userName,String pass)
        //{
        //    if (UserName == userName && Password == pass)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public bool Login(String userName, String pass,String email)
        //{
        //    if (UserName == userName && Password == pass && Email == email)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        //parametre de email optionnelle
        public bool Login(String userName, String pass, String email = null)
        {
            if (email != null)
            {
                if (UserName == userName && Password == pass&&Email==email)
                {
                    return true;

                }
            }
            else
            {
                if (UserName == userName && Password == pass)
                {
                    return true;

                }
            }
            return false;
        }

        public void GetProducts(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Name":{ 
                        foreach(Product p in Products)
                        {
                            if(p.Name == filterValue)
                            {
                                p.GetDetails();
                            }
                        }
                        break;
                 }
                case "DateProd": {
                        foreach (Product p in Products)
                        {
                            if (p.DateProd.ToString() == filterValue)
                            {
                                p.GetDetails();
                            }
                        }
                        break; 
                 }
                case "Description":{
                        foreach (Product p in Products)
                        {
                            if (p.Description == filterValue)
                            {
                                p.GetDetails();
                            }
                        }
                        break; }
                case "Price":{
                        foreach (Product p in Products)
                        {
                            if (p.Price == Double.Parse(filterValue) )
                            {
                                p.GetDetails();
                            }
                        }
                        break; }
                case "ProductId":{
                        foreach (Product p in Products)
                        {
                            if (p.ProductId == int.Parse(filterValue))
                            {
                                p.GetDetails();
                            }
                        }
                        break; }
                case "Quantity":{
                        foreach (Product p in Products)
                        {
                            if (p.Quantity == Double.Parse(filterValue))
                            {
                                p.GetDetails();
                            }
                        }
                        break; }
            }
        }
        /*
            public void GetProducts(string filterType, string filterValue)
        {
            IEnumerable<Product> query = new List<Product>();
            if (filterType == "Name")
            {
                query = from product in Products
                        where product.Name == filterValue
                        select product;
            }else
            if (filterType == "DateProd")
            {
                DateTime oDate = Convert.ToDateTime(filterValue);
                query = from product in Products
                        where product.DateProd == oDate
                        select product;
            }else
            if (filterType == "Description")
            {
                query = from product in Products
                        where product.Description == filterValue
                        select product;
            }else
            if (filterType == "Price")
            {
                double doubleVal = Convert.ToDouble(filterType);
                query = from product in Products
                        where product.Price == doubleVal
                        select product;
            }else
            if (filterType == "Price")
            {
                double doubleVal = Convert.ToDouble(filterType);
                query = from product in Products
                        where product.Price == doubleVal
                        select product;
            }else
            if (filterType == "ProductId")
            {
                int doubleVal = Convert.ToInt32(filterType);
                query = from product in Products
                        where product.Price == doubleVal
                        select product;
            }else
            if (filterType == "Quantity")
            {
                int doubleVal = Convert.ToInt32(filterType);
                query = from product in Products
                        where product.Price == doubleVal
                        select product;
            }

            foreach (Product str in query)
            {
                str.GetDetails();
            }
        */


        }

        }
    
