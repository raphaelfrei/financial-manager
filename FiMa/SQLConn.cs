using System;
using Microsoft.Data.Sqlite;
using FiMa.Models;
using Microsoft.Maui.Controls;

public static class SQLConn {

    private static string DBName = "dbase.db";
    private static string ConnectionString = $"Data Source={DBName};";

    //$"";
    public static (bool, string) AddUser(User user) {

        CreateDatabaseIfNotExists();

        bool status = false;
        string message = string.Empty;

        string selectCommand = $"SELECT COUNT(*) FROM usuario WHERE email_usuario='{user.EmailUsuario}'";
        string createCommand = $"INSERT INTO usuario (nome_usuario, email_usuario, data_nasc_usuario, genero_usuario, vai_investir_usuario, vai_quitar_div_usuario, vai_controlar_gast_usuario, vai_planejar_usuario, renda_usuario, despesa_fixa_usuario, senha_usuario, primeiro_login) VALUES ('{user.NomeUsuario}', '{user.EmailUsuario}', '{user.DataNascimento}', {user.GeneroUsuario}, {user.VaiInvestir}, {user.VaiQuitarDivida}, {user.VaiControlarGastos}, {user.VaiPlanejar}, {user.RendaMensal.ToString().Replace(',', '.')}, {user.DespesaFixa.ToString().Replace(',', '.')}, '{user.SenhaUsuario}', 1)";
        try {

            using (var conn = new SqliteConnection(ConnectionString)) {
                conn.Open();

                using (var command = new SqliteCommand(selectCommand, conn)) {

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count == 0) {
                        using (var cmdd = new SqliteCommand(createCommand, conn)) {

                            cmdd.ExecuteNonQuery();

                            status = true;
                            message = "Conta criada com sucesso!";

                        }
                    } else {
                        status = false;
                        message = "Já existe uma conta criada com esse email. Verifique e tente novamente.";
                    }
                }

                conn.Close();
            }
        } catch (Exception ex) {
            status = false;
            message = ex.ToString();
        }

        return (status, message);
    }

    public static int GetEmailCount(string email) {

        int count = 0;

        string selectCommand = $"SELECT COUNT(*) FROM usuario WHERE email_usuario='{email}'";
        try {

            using (var conn = new SqliteConnection(ConnectionString)) {
                conn.Open();

                using (var command = new SqliteCommand(selectCommand, conn)) {

                    count = Convert.ToInt32(command.ExecuteScalar());

                }

                conn.Close();
            }
        } catch (Exception) {

        }

        return count;
    }

    public static int TryLogin(string email, string password) {

        CreateDatabaseIfNotExists();

        // Status 0 - Não deveria retornar
        // Status 1 - Login OK
        // Status 2 - Usuário não encontrado
        // Status 3 - Senha incorreta

        string selectCommand = $"SELECT senha_usuario FROM usuario WHERE email_usuario='{email}'";
        string countCommand = $"SELECT COUNT(*) FROM usuario WHERE email_usuario='{email}'";

        //try {

        using (var conn = new SqliteConnection(ConnectionString)) {
            conn.Open();

            using (var cmd = new SqliteCommand(countCommand, conn)) {

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 0)
                    return 2;

                using (var cmdd = new SqliteCommand(selectCommand, conn)) {
                    using (var reader = cmdd.ExecuteReader()) {
                        if (reader.Read()) {
                            string storedPassword = reader.GetString(reader.GetOrdinal("senha_usuario"));

                            if (storedPassword == ConvertToMD5.ConvertStringToMD5(password))
                                return 1;
                            else
                                return 3;
                        }
                    }
                }

            }

            conn.Close();
        }

        //} catch (Exception) {

        //}

        return 0;

    }

    private static void CreateDatabaseIfNotExists() {

        using (var conn = new SqliteConnection(ConnectionString)) {
            conn.Open();

            //DropAllTables();

            string TableDespesa = "CREATE TABLE IF NOT EXISTS \"despesa\" (\"id_despesa\" INTEGER UNIQUE,\"valor_despesa\" INTEGER,\"descricao_despesa\" TEXT,\"categoria_despesa\" TEXT,\"data_despesa\" TEXT,\"forma_pagamento_despesa\" TEXT,\"parcelamento_despesa\" INTEGER,\"id_usuario\" INTEGER, PRIMARY KEY(\"id_despesa\" AUTOINCREMENT))";
            string TableReceita = "CREATE TABLE IF NOT EXISTS \"receita\"(\"id_receita\" INTEGER UNIQUE,\"valor_receita\" INTEGER,\"descricao_receita\" TEXT,\"comentario_receita\" INTEGER,\"id_usuario\" INTEGER, PRIMARY KEY(\"id_receita\"))";
            string TableUsuario = "CREATE TABLE IF NOT EXISTS \"usuario\" (\"id_usuario\" INTEGER NOT NULL UNIQUE,\"nome_usuario\" TEXT NOT NULL,\"email_usuario\" TEXT NOT NULL UNIQUE,\"data_nasc_usuario\" TEXT NOT NULL,\"genero_usuario\" INTEGER NOT NULL,\"vai_investir_usuario\" INTEGER,\"vai_quitar_div_usuario\" INTEGER,\"vai_controlar_gast_usuario\" INTEGER,\"vai_planejar_usuario\" INTEGER,\"renda_usuario\" NUMERIC,\"despesa_fixa_usuario\" INTEGER,\"senha_usuario\" INTEGER NOT NULL,\"primeiro_login\" INTEGER, PRIMARY KEY(\"id_usuario\" AUTOINCREMENT))";

            using (var command = new SqliteCommand(TableDespesa, conn)) {
                command.ExecuteNonQuery();
            }

            using (var command = new SqliteCommand(TableReceita, conn)) {
                command.ExecuteNonQuery();
            }

            using (var command = new SqliteCommand(TableUsuario, conn)) {
                command.ExecuteNonQuery();
            }

            conn.Close();
        }
    }

    private static void DropAllTables() {
        using (var conn = new SqliteConnection(ConnectionString)) {
            conn.Open();

            var command = new SqliteCommand($"DROP TABLE IF EXISTS despesa", conn);
            command.ExecuteNonQuery();

            command = new SqliteCommand($"DROP TABLE IF EXISTS receita", conn);
            command.ExecuteNonQuery();

            command = new SqliteCommand($"DROP TABLE IF EXISTS usuario", conn);
            command.ExecuteNonQuery();

            conn.Close();
        }
    }


}


