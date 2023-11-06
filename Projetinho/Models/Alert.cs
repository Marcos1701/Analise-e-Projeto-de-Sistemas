using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projetinho.Models
{
    public class Alert
    {
        
        [Display(Name = "Código")]
        public int Id {get; set;}

        [Required(ErrorMessage = "Data de Emissão é obrigatória")]
        [Display(Name = "Data de Emissão")]
        [DataType(DataType.Date)]
        public DateTime IssueDate {get; set;}

        [Required(ErrorMessage = "Título do livro é obrigatório")]
        [Display(Name = "Título do livro")]
        public string BookName {get; set;}

        [Display(Name = "Data de Retorno")]
        [DataType(DataType.Date)]
        public DateTime? ReturnDate {get; set;}

        [Display(Name = "Multa")]
        public int? Fine {get; set;}

        [Display(Name = "Status")]
        public bool IsActivated = false;

        public virtual Libraian? Libraian {get; set;}

        public Alert()
        {
            IssueDate = DateTime.Now;
            ReturnDate = IssueDate.AddDays(15);
            Fine = 100;
        }

        public Alert(Libraian libraian, string bookname)
        {
            Libraian = libraian;
            BookName = bookname;
        }

        public void Finecall()
        {
            int daysOverdue = (int)(DateTime.Now - ReturnDate.Value).TotalDays;

            if (daysOverdue > 0)
            {
                Fine = daysOverdue * Fine;
            }
        }

        public string ViewAlert()
        {
            return  "Código: " + Id +
                    "\nData de Emissão: " + IssueDate + 
                    "\nNome do Livro: " + BookName + 
                    "\nData de Retorno: "+ ReturnDate +
                    "\nMulta: " + Fine;
        }

        public void Sendtolibraian()
        {
            if (Libraian == null)
            {
                Console.WriteLine("Alerta nao ativado.");
            }

            if (DateTime.Now > ReturnDate && !IsActivated)
            {
                Finecall();
                IsActivated = true;
            }

            Console.WriteLine($"Alerta para o livro {BookName} foi enviado ao bibliotecario {Libraian?.Name}.");
        }

        public void Deletealrtbyno(int alertId)
        {
            Alert? delete = Libraian.Alerts.FirstOrDefault(alert => alert.Id == alertId);

            if (delete == null)
            {
                Console.WriteLine("Alerta nao encontrado.");
                return;
            }

            Libraian.Alerts.Remove(delete);
            Console.WriteLine("Alerta removido.");
        }
    }
}