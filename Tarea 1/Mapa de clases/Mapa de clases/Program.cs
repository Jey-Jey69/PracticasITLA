using Mapa_de_clases;

internal class Program
{
    static void Main(string[] args)
    {
        // Administrador
        Administrador admin = new Administrador();
        admin.nombre = "Carlos";
        admin.edad = 45;
        admin.saludar();
        admin.Gestionar();
        Console.WriteLine();

        // Administrativo
        Administrativo admini = new Administrativo();
        admini.nombre = "Ana";
        admini.edad = 30;
        admini.saludar();
        admini.Archivar();
        Console.WriteLine();

        // Docente
        Docente profe = new Docente();
        profe.nombre = "Luis";
        profe.edad = 40;
        profe.saludar();
        profe.Enseñar();
        Console.WriteLine();

        // Empleado
        Empleado emple = new Empleado();
        emple.nombre = "María";
        emple.edad = 35;
        emple.saludar();
        emple.Trabajar();
        Console.WriteLine();

        // Estudiante
        Estudiante estudiante1 = new Estudiante();
        estudiante1.nombre = "Pedro";
        estudiante1.edad = 20;
        estudiante1.saludar();
        estudiante1.Estudiar();
        Console.WriteLine();

        // Exalumno
        ExAlumno exalum = new ExAlumno();
        exalum.nombre = "Sofía";
        exalum.edad = 28;
        exalum.saludar();
        exalum.Recordar();
        Console.WriteLine();


        // Maestro
        Maestro maestro1 = new Maestro();
        maestro1.nombre = "Jorge";
        maestro1.edad = 50;
        maestro1.saludar();
        maestro1.DarClase();
        Console.WriteLine();
    }
}
