using System;
using System.Collections.Generic;
using Series.Interfaces;

namespace Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
         private List<Serie> listSerie = new List<Serie>();
        public void Exclui(int id)
        {
            listSerie[id].ToDelete();
        }

        public void Insere(Serie objeto)
        {
            listSerie.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return listSerie;
        }

        public int ProximoId()
        {
            return listSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listSerie[id];
        }

        public void Atualiza(int id, Serie objeto)
        {
            listSerie[id] = objeto;
        }
    }
}