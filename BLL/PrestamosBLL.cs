using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegistroPrestamo.Models;
using RegistroPrestamo.DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace RegistroPrestamo.BLL
{
    public class PrestamosBLL
    {

        public static bool Existe(int id)//determina si existe el prestamo
        {
            Contexto db = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = db.Prestamos.Any(p => p.PrestamoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return encontrado;
        }

        public static bool Insertar(Prestamos prestamos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Prestamos.Add(prestamos);
                paso = db.SaveChanges() > 0;
                AfectarBalance(prestamos);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Prestamos prestamos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(prestamos).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
                AfectarBalance(prestamos);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Guardar(Prestamos prestamos)
        {
            if (!Existe(prestamos.PrestamoId))
                return Insertar(prestamos);
            else
                return Modificar(prestamos);
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var prestamo = db.Prestamos.Find(id);

                if (prestamo != null)
                {
                    db.Prestamos.Remove(prestamo);//remueve la entidad
                    paso = db.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Prestamos Buscar(int id)
        {
            Contexto db = new Contexto();
            Prestamos prestamos;

            try
            {
                prestamos = db.Prestamos.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return prestamos;
        }

        private static bool AfectarBalance(Prestamos prestamo)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                prestamo.Balance = prestamo.Monto;

                db.Personas.Find(prestamo.PersonaId).Balance = prestamo.Balance;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static List<Prestamos> GetPRestamos()
        {
            List<Prestamos> lista = new List<Prestamos>();
            Contexto db = new Contexto();
            try
            {
                lista = db.Prestamos.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }

        public static List<Prestamos> GetList(Expression<Func<Prestamos, bool>> criterio)
        {
            List<Prestamos> lista = new List<Prestamos>();
            Contexto db = new Contexto();
            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                lista = db.Prestamos.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return lista;
        }
    }
}
