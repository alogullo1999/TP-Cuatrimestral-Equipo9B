﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using dominio;

namespace negocio
{
    public class ClienteNegocio
    {
        public Cliente ObtenerCliente(int id)
        {
            AccesoDatos datos= new AccesoDatos();
            Cliente cliente= new Cliente();

            try
            {
                datos.setearConsulta("SELECT IdCliente,Nombre,Apellido,Dni,Email,Ciudad FROM Clientes;");
                datos.setearParametro("@id", id);

                if (datos.Lector.Read())
                {
                    cliente.IdCliente = (int)datos.Lector["IdCliente"];
                    cliente.Nombre = (string)datos.Lector["Nombre"];
                    cliente.Apellido = (string)datos.Lector["Apellido"];
                    cliente.Dni = (string)datos.Lector["Dni"];
                    cliente.Email = (string)datos.Lector["Email"];
                    cliente.Ciudad = (string)datos.Lector["Ciudad"];
                }
                return cliente;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool ExisteCliente(string nombre)
        {
            AccesoDatos datos= new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Clientes WHERE Nombre=@Nombre");
                datos.setearParametro("@Nombre", nombre);
                datos.EjecutarLectura();

                if (datos.Lector.Read() && (int)datos.Lector[0]>0)
                {
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void AgregarCliente(Cliente cliente)
        {
            if (string.IsNullOrWhiteSpace(cliente.Nombre))
            throw new ArgumentException("El nombre del cliente es obligatorio");

            if (string.IsNullOrWhiteSpace(cliente.Apellido))
                throw new ArgumentException("El apellido del cliente es obligatorio");

            if (string.IsNullOrWhiteSpace(cliente.Dni))
                throw new ArgumentException("El Dni del cliente es obligatorio");

            if (string.IsNullOrWhiteSpace(cliente.Email))
                throw new ArgumentException("El Email del cliente es obligatorio");

            if (string.IsNullOrWhiteSpace(cliente.Ciudad))
                throw new ArgumentException("La ciudad del cliente es obligatorio");

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"INSERT INTO Cliente(Dni,Nombre,Apellido,Email,Ciudad) VALUES (@Dni,@Nombre,@Apellido,@Email,@Ciudad)");

                datos.setearParametro("@Dni", cliente.Dni);
                datos.setearParametro("@Nombre", cliente.Nombre);
                datos.setearParametro("@Apellido", cliente.Apellido);
                datos.setearParametro("@Email", cliente.Email);
                datos.setearParametro("@Ciudad", cliente.Ciudad);

                datos.ejecutarAccion();
            }
            catch (Exception ex) {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            
        }
    }
}