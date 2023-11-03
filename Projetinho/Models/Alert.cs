using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projetinho.Models
{
    public class Alert
    {
        [Display(Name = "Código")]
        public int Id {get; set;}

        [Display(Name = "Data de Emissão")]
        public DateTime IssueDate {get; set;}

        [Display(Name = "Nome do Livro")]
        public string BookName {get; set;}

        [Display(Name = "Data de Retorno")]
        public DateTime ReturnDate {get; set;}

        [Display(Name = "Multa")]
        public int Fine {get; set;}

        [Display(Name = "Status")]
        public bool IsActivated { get; set; }

        public virtual Libraian Libraian {get; set;}

        public Alert(Libraian libraian, string bookname, DateTime returndate)
        {
            IsActivated = false;
            IssueDate = DateTime.Now;
            Libraian = libraian;
            BookName = bookname;
            ReturnDate = returndate;
            Fine = 100;
        }

        public void Finecall()
        {
            int daysOverdue = (int)(DateTime.Now - ReturnDate).TotalDays;

            if (daysOverdue > 0)
            {
                Fine = daysOverdue * 3; // R$3,00
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