using System;
using System.Collections.Generic;
using System.Text;
using System.Data;//adicionei
using MySqlConnector;//adicionei
using WS01.Models; //adiconei

namespace WS01.Controller
{
    public class MySQLCon
    {
        static string conn = @"server=db4free.net;port=3306;database=aula2023;user id=camargo;password=abc321973;charset=utf8";

        public static List<Pessoa> ListarPessoas()
        {
            List<Pessoa> listapessoas = new List<Pessoa>();
            string sql = "SELECT * FROM pessoa";
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pessoa pessoa = new Pessoa()
                            {
                                id = reader.GetInt32(0),
                                nome = reader.GetString(1),
                                idade = reader.GetString(2)
                            };
                            listapessoas.Add(pessoa);

                        }
                    }
                }
                con.Close();
                return listapessoas;
            }
        }

        public static void Inserir(string nome, string idade)
        {
            string sql = "INSERT INTO pessoa(nome,idade) VALUES(@nome,@idade)";
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using(MySqlCommand cmd = new MySqlCommand(sql,con))
                {
                    cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = nome;
                    cmd.Parameters.Add("@idade", MySqlDbType.VarChar).Value = idade;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }

        }
        public static void Atualizar(Pessoa pessoa)
        {
            string sql = "UPDATE pessoa SET nome=@nome, idade=@idade WHERE id=@id";
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = pessoa.nome;
                    cmd.Parameters.Add("@idade", MySqlDbType.VarChar).Value = pessoa.idade;
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = pessoa.id;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
        public static void Excluir(int id)
        {
            string sql = "DELETE FROM pessoa WHERE id=@id";
            using (MySqlConnection con = new MySqlConnection(conn))
            {
                con.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }

    }
}
