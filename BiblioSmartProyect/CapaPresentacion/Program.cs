using System;
using CapaNegocio;
using CapaEntidades;

namespace CapaPresentacion
{
    class Program
    {
        static void Main(string[] args)
        {
            LibroNegocio libroNeg = new LibroNegocio();
            UsuarioNegocio usuarioNeg = new UsuarioNegocio();
            PrestamoNegocio prestamoNeg = new PrestamoNegocio();

            // ===== DATOS DE PRUEBA =====
            // Libros
            libroNeg.AgregarLibro(new Libro { Titulo = "C# Básico", Autor = "Juan Pérez" });
            libroNeg.AgregarLibro(new Libro { Titulo = "UML Gota a Gota", Autor = "Ana Gómez" });
            libroNeg.AgregarLibro(new Libro { Titulo = "Programación Orientada a Objetos", Autor = "María López" });

            // Usuarios
            usuarioNeg.AgregarUsuario(new Usuario { Nombre = "EzzyRD" });
            usuarioNeg.AgregarUsuario(new Usuario { Nombre = "Pana123" });
            usuarioNeg.AgregarUsuario(new Usuario { Nombre = "AnaUser" });

            // Préstamos de prueba
            prestamoNeg.AgregarPrestamo(new Prestamo
            {
                UsuarioId = 1, // EzzyRD
                LibroId = 2,   // UML Gota a Gota
                FechaPrestamo = DateTime.Now.AddDays(-3) // hace 3 días
            });

            prestamoNeg.AgregarPrestamo(new Prestamo
            {
                UsuarioId = 2, // Pana123
                LibroId = 1,   // C# Básico
                FechaPrestamo = DateTime.Now.AddDays(-1) // hace 1 día
            });
            // ============================

            bool salir = false;

            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("=== Biblioteca BiblioSmart ===");
                Console.WriteLine("1. Gestionar Libros");
                Console.WriteLine("2. Gestionar Usuarios");
                Console.WriteLine("3. Gestionar Préstamos");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MenuLibros(libroNeg);
                        break;
                    case "2":
                        MenuUsuarios(usuarioNeg);
                        break;
                    case "3":
                        MenuPrestamos(prestamoNeg, usuarioNeg, libroNeg);
                        break;
                    case "4":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Presione Enter...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void MenuLibros(LibroNegocio libroNeg)
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("=== Gestión de Libros ===");
                Console.WriteLine("1. Listar Libros");
                Console.WriteLine("2. Agregar Libro");
                Console.WriteLine("3. Eliminar Libro");
                Console.WriteLine("4. Volver");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        var libros = libroNeg.ObtenerLibros();
                        Console.WriteLine("ID\tTítulo\tAutor");
                        foreach (var libro in libros)
                        {
                            Console.WriteLine($"{libro.Id}\t{libro.Titulo}\t{libro.Autor}");
                        }
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Write("Título: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Autor: ");
                        string autor = Console.ReadLine();
                        libroNeg.AgregarLibro(new Libro { Titulo = titulo, Autor = autor });
                        Console.WriteLine("Libro agregado!");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Write("ID del libro a eliminar: ");
                        int idEliminar = int.Parse(Console.ReadLine());
                        libroNeg.EliminarLibro(idEliminar);
                        Console.WriteLine("Libro eliminado!");
                        Console.ReadLine();
                        break;
                    case "4":
                        volver = true;
                        break;
                }
            }
        }

        static void MenuUsuarios(UsuarioNegocio usuarioNeg)
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("=== Gestión de Usuarios ===");
                Console.WriteLine("1. Listar Usuarios");
                Console.WriteLine("2. Agregar Usuario");
                Console.WriteLine("3. Eliminar Usuario");
                Console.WriteLine("4. Volver");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        var usuarios = usuarioNeg.ObtenerUsuarios();
                        Console.WriteLine("ID\tNombre");
                        foreach (var usuario in usuarios)
                        {
                            Console.WriteLine($"{usuario.Id}\t{usuario.Nombre}");
                        }
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Write("Nombre: ");
                        string nombre = Console.ReadLine();
                        usuarioNeg.AgregarUsuario(new Usuario { Nombre = nombre });
                        Console.WriteLine("Usuario agregado!");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Write("ID del usuario a eliminar: ");
                        int idEliminar = int.Parse(Console.ReadLine());
                        usuarioNeg.EliminarUsuario(idEliminar);
                        Console.WriteLine("Usuario eliminado!");
                        Console.ReadLine();
                        break;
                    case "4":
                        volver = true;
                        break;
                }
            }
        }

        static void MenuPrestamos(PrestamoNegocio prestamoNeg, UsuarioNegocio usuarioNeg, LibroNegocio libroNeg)
        {
            bool volver = false;
            while (!volver)
            {
                Console.Clear();
                Console.WriteLine("=== Gestión de Préstamos ===");
                Console.WriteLine("1. Listar Préstamos");
                Console.WriteLine("2. Registrar Préstamo");
                Console.WriteLine("3. Devolver Libro");
                Console.WriteLine("4. Volver");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        var prestamos = prestamoNeg.ObtenerPrestamos();
                        Console.WriteLine("ID\tUsuario\tLibro\tFecha Préstamo\tFecha Devolución");
                        foreach (var p in prestamos)
                        {
                            Console.WriteLine($"{p.Id}\t{usuarioNeg.ObtenerUsuarioPorId(p.UsuarioId).Nombre}\t{libroNeg.ObtenerLibroPorId(p.LibroId).Titulo}\t{p.FechaPrestamo.ToShortDateString()}\t{p.FechaDevolucion?.ToShortDateString() ?? "-"}");
                        }
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.Write("ID del Usuario: ");
                        int idUsuario = int.Parse(Console.ReadLine());
                        Console.Write("ID del Libro: ");
                        int idLibro = int.Parse(Console.ReadLine());
                        prestamoNeg.AgregarPrestamo(new Prestamo
                        {
                            UsuarioId = idUsuario,
                            LibroId = idLibro,
                            FechaPrestamo = DateTime.Now
                        });
                        Console.WriteLine("Préstamo registrado!");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Write("ID del Préstamo: ");
                        int idPrestamo = int.Parse(Console.ReadLine());
                        prestamoNeg.DevolverLibro(idPrestamo);
                        Console.WriteLine("Libro devuelto!");
                        Console.ReadLine();
                        break;
                    case "4":
                        volver = true;
                        break;
                }
            }
        }
    }
}
