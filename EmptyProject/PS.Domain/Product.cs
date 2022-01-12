using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PS.Domain
{
    public class Product:Concept
    {


        [Display(Name="date valide")]  //lAffichage par default si aucun date ajouter
        [DataType(DataType.Date)]      //date valide 
        public DateTime DateProd { get; set; }

        [DataType(DataType.MultilineText)]  
        public String Description { get; set; }

        [Required(ErrorMessage="le champ est obligatoir") ]
        [StringLength(25, ErrorMessage="long maximal 25")] //tnjm tkoun intervall entre 25,50
        [MaxLength(50)]                                    //l'input gadeh ynjm yhez min caractere
        public String Name { get; set; }

        [DataType(DataType.Currency)]
        public Double Price { get; set; }
        public int ProductId { get; set; }



        [Range(0,int.MaxValue)]
        public int Quantity { get; set; }

        public String Image { get; set; }



        //les relation entreles tables 

         
        public virtual Category MyCategory { get; set; }

        //on peut declarer le cle etranger de categorie ici


        [ForeignKey("CategoryFK")]
        public int CategoryId { get; set; }  //int tet3ada    w b   int?   y9bel null






        [NotMapped]
        public virtual IList<Provider> Providers { get; set; }

        public override void GetDetails()
        {
            Console.WriteLine("Productname :" + Name + "   / Price:" + Price + "   /quantity:" + Quantity + "   /description:" + Description);
        }

        public virtual void GetMyType()
        {
            Console.WriteLine("UNKNOWN");
        }
        
    }
}
