using DIO.Series.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Series.Classes
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> ListaSerie = new List<Serie>();
        public void Atualiza(int Id, Serie Objeto) 
        {
            ListaSerie[Id] = Objeto;
        }

        public void Exclui(int Id)
        {
            ListaSerie[Id].Exclui();
        }

        public void Insere(Serie Objeto)
        {
            ListaSerie.Add(Objeto);
        }

        public List<Serie> Lista()
        {
            return ListaSerie;
        }

        public int ProximoId()
        {
            return ListaSerie.Count;
        }

        public Serie RetornaPorId(int Id)
        {
            return ListaSerie[Id];
        }
    }
}
