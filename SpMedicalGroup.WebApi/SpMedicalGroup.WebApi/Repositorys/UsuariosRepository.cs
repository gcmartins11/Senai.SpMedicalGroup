﻿using Microsoft.EntityFrameworkCore;
using SpMedicalGroup.WebApi.Domains;
using SpMedicalGroup.WebApi.Interfaces;
using SpMedicalGroup.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SpMedicalGroup.WebApi.Repositorys
{
    public class UsuariosRepository : IUsuariosRepository
    {
        //private string StringConexao = "Data Source=.\\SqlExpress;" +
        //"initial catalog=SPMEDICALGROUP_MANHA;" +
        //"USER ID = sa; Pwd = 132";

        public Usuarios BuscarEmailSenha(string email, string senha)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                var usuario = ctx.Usuarios.Include(i => i.IdCredencialNavigation).FirstOrDefault(x => x.Email == email && x.Senha == senha);

                if (usuario == null)
                {
                    return null;
                }

                return usuario;

                //return ctx.Usuarios.FirstOrDefault(x => x.Email == email && x.Senha == senha);
            }
        }


        public void Cadastrar(CadastroViewModel usuarioCadastrado)
        {
            
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                Usuarios usuario = new Usuarios()
                {
                    Email = usuarioCadastrado.Email,
                    Senha = usuarioCadastrado.Senha,
                    IdCredencial = usuarioCadastrado.IdCredencial
                };

                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();

                Pacientes paciente = new Pacientes()
                {
                    Nome = usuarioCadastrado.Nome,
                    Rg = usuarioCadastrado.Rg,
                    Cpf = usuarioCadastrado.Cpf,
                    DataNascimento = usuarioCadastrado.DataNascimento,
                    Telefone = usuarioCadastrado.Telefone,
                    Logradouro = usuarioCadastrado.Logradouro,
                    Numero = usuarioCadastrado.Numero,
                    Bairro = usuarioCadastrado.Bairro,
                    Cidade = usuarioCadastrado.Cidade,
                    Estado = usuarioCadastrado.Estado,
                    IdUsuario = ctx.Usuarios.Count()
                };


                ctx.Pacientes.Add(paciente);
                ctx.SaveChanges();
            }
        }

        public Usuarios GetById(int id)
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                var UsuarioProcurado = ctx.Usuarios.Find(id);
                var usuarioMostrado = new Usuarios
                {
                    Id = UsuarioProcurado.Id,
                    Email = UsuarioProcurado.Email,
                    IdCredencial = UsuarioProcurado.IdCredencial,
                };
                
                return usuarioMostrado;
            }    
        }

        public List<Medicos> GetMedicos()
        {
            using(SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return ctx.Medicos.ToList();
            }
        }

        public List<Pacientes> GetPacientes()
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                return ctx.Pacientes.ToList();
            }
        }

        public List<Usuarios> Listar()
        {
            using (SpMedGroupContext ctx = new SpMedGroupContext())
            {
                List<Usuarios> usuariosProcurados = ctx.Usuarios.ToList();
                List<Usuarios> usuariosMostrados = new List<Usuarios>();

                foreach (var usuario in usuariosProcurados)
                {
                    var usuarioMostrado = new Usuarios
                    {
                        Id = usuario.Id,
                        Email = usuario.Email,
                        IdCredencial = usuario.IdCredencial
                    };

                    usuariosMostrados.Add(usuarioMostrado);
                }

                return usuariosMostrados;

            }

            //List<Usuarios> usuarios = new List<Usuarios>();

            //using (SqlConnection con = new SqlConnection(StringConexao))

            //{
            //    string querySelect = "SELECT ID, EMAIL, ID_CREDENCIAL FROM USUARIOS";

            //    con.Open();

            //    SqlDataReader sdr;

            //    using (SqlCommand cmd = new SqlCommand(querySelect, con))
            //    {
            //        sdr = cmd.ExecuteReader();

            //        if (sdr.HasRows)
            //        {
            //            while (sdr.Read())
            //            {
            //                Usuarios usuario = new Usuarios
            //                {
            //                    Id = Convert.ToInt32(sdr["ID"]),
            //                    Email = sdr["EMAIL"].ToString(),
            //                    IdCredencial = Convert.ToInt32(sdr["ID_CREDENCIAL"]),
            //                };

            //                usuarios.Add(usuario);
            //            }

            //            return usuarios;
            //        }

            //    }

            //    return null;

            //}


        }
    }
}
