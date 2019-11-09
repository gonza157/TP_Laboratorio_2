using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Biblioteca.Entidades
{
  public class Jornada
  {
    private List<Alumno> alumnos;
    private Universidad.EClases clase;
    private Profesor instructor;




    public List<Alumno> Alumnos
    {
      get
      {
        return this.alumnos;
      }
      set
      {
        this.alumnos = value;
      }
    }


    public Universidad.EClases Clase
    {
      get
      {
        return this.clase;
      }
      set
      {
        this.clase = value;
      }
    }

    public Profesor Instructores
    {
      get
      {
        return this.instructor;
      }
      set
      {
        this.instructor = value;
      }
    }

    public Jornada()
    {
      alumnos = new List<Alumno>();
    }

    public Jornada(Universidad.EClases clase, Profesor instructor)
    {

    }

    string Leer()
    {
      return this.ToString();
    }

    public static bool operator !=(Jornada j, Alumno a)
    {
      return !(j == a);
    }

    public static bool operator ==(Jornada j, Alumno a)
    {
      bool flag = false;
      foreach (Alumno aux in j.alumnos)
      {
        if (a == aux)
        {
          flag = true;
        }
      }
      return flag;
    }

    public static Jornada operator +(Jornada j, Alumno a)
    {
      bool flag = false;
      foreach (Alumno aux in j.alumnos)
      {
        if (aux != j.clase && aux != a)
        {
          flag = true;
        }
      }
      if (flag == true)
      {
        j.alumnos.Add(a);
      }
      return j;
    }

    public override string ToString()
    {
      StringBuilder srt = new StringBuilder();
      srt.AppendLine(this.clase.ToString());
      srt.AppendLine(this.instructor.ToString());
      srt.AppendLine("Alumnos :");
      foreach (Alumno aux in this.alumnos)
      {
        srt.AppendLine(aux.ToString());
      }

      return srt.ToString();
    }

    bool Guardar(Jornada jornada)
    {
      try
      {
        StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\prueba.txt", true);
        //string s = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+"\\prueba";

        sw.WriteLine(jornada.ToString());

        sw.Close();
        return true;

      }
      catch (Exception ex)
      {
       
        return false;
      }

     
    }



  }
}

