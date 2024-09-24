using MediProjectWebApp.Helpers;
using MediProjectWebApp.Models;
using MediProjectWebApp.Models.Enums;
using MediProjectWebApp.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediProjectWebApp.Services
{
    public class ProjectDaoService : ConnectionStringHelper, IProjectDaoService
    {

        public QueryStatus CreateProject(Project project)
        {
            // SQL Insert Command
            string insertQuery = "INSERT INTO projects (project_name, project_enabled, accept_new_visits, supported_image_type) " +
                                 "VALUES (:projectName, :projectEnabled, :acceptNewVisits, :supportedImageType)";

            using (var connection = new NpgsqlConnection(connString))
            {
                using (var command = new NpgsqlCommand(insertQuery, connection))
                {
                    // Add parameters
                    command.Parameters.AddWithValue(":projectName", project.ProjectName);
                    command.Parameters.AddWithValue(":projectEnabled", project.ProjectEnabled);
                    command.Parameters.AddWithValue(":acceptNewVisits", project.AcceptNewVisits);
                    command.Parameters.AddWithValue(":supportedImageType", project.SupportedImageType.ToString());

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return QueryStatus.Success;
                    }
                    catch (Exception ex)
                    {
                        ILoggerFactory factory = new LoggerFactory();
                        ILogger logger = factory.CreateLogger("Error");
                        logger.LogError(ex.Message);
                    }
                }
            }
            return QueryStatus.Failed;
        }

        public QueryStatus DeleteProject(Project project)
        {
            throw new NotImplementedException();
        }

        public List<Project> ReadAllProjects()
        {
            List<Project> projects = new List<Project>();
            using (var conn = new NpgsqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    using (var cmd = new NpgsqlCommand("SELECT * FROM PROJECTS", conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                long id = Convert.ToInt64(reader["id"]);
                                string name = (string)reader["project_name"];
                                bool enabled = (bool)reader["project_enabled"];
                                bool accept = (bool)reader["accept_new_visits"];
                                string image = (string)reader["supported_image_type"];
                                DateTime created = (DateTime)reader["created_at"];
                                ImageTypeEnum imageEnum;
                                Enum.TryParse<ImageTypeEnum>(image, out imageEnum);
                                projects.Add(new Project(id, name, enabled, accept, imageEnum, created));
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    ILoggerFactory factory = new LoggerFactory();
                    ILogger logger = factory.CreateLogger("Error");
                    logger.LogError(ex.Message);
                }
            }
            return projects;
        }

        public Project ReadProject(long idProject)
        {
            throw new NotImplementedException();
        }

        public QueryStatus UpdateProject(Project project)
        {
            throw new NotImplementedException();
        }
    }
}