using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Entidades
{
  public class Universidad
  {
    public enum EClases
    {
      Progamacion,
      Laboratorio,
      Legislacion,
      SPD
    }

    private List<Alumno> alumnos;
    private List<Jornada> jornada;
    private List<Profesor> profesores;


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

    public List<Profesor> Instructores
    {
      get
      {
        return this.profesores;
      }
      set
      {
        this.profesores = value;
      }
    }


    public List<Jornada> Jornadas
    {
      get
      {
        return this.jornada;
      }
      set
      {
        this.jornada = value;
      }
    }
    /*

    public Jornada this[int i] 
    {
        get
        {
           // return ;
        }
        set
        {
            this.jornada = value;
        }
    }*/

    public Universidad()
    {

    }

    public static bool operator !=(Universidad g, Alumno a)
    {
      return false;
    }

    public static bool operator !=(Universidad g, Profesor i)
    {
      return false;
    }

    public static Profesor operator !=(Universidad u, EClases clase)
    {
      Profesor p = new Profesor();
      return p;
    }

    public static bool operator ==(Universidad g, Alumno a)
    {
      return false;
    }

    public static bool operator ==(Universidad g, Profesor i)
    {
      return false;
    }

    public static Profesor operator ==(Universidad u, EClases clase)
    {
      Profesor p = new Profesor();
      return p;
    }

    public static Universidad operator +(Universidad u, Alumno a)
    {
      bool flag = false;
      foreach (Alumno aux in u.alumnos)
      {
        if(aux == a)
        {
          flag = true;
        }
      }
      if(flag == true)
      {
        u.alumnos.Add(a);
      }
      return u;
    }

    public static Universidad operator +(Universidad u, Profesor i)
    {
      bool flag = false;
      foreach (Profesor aux in u.profesores)
      {
        if (aux == i)
        {
          flag = true;
        }
      }
      if (flag == true)
      {
        u.profesores.Add(i);
      }
      return u;
    }

    public static Universidad operator +(Universidad g, EClases clase)
    {
      return g;
    }

    public Universidad Leer()
    {
      Universidad u = new Universidad();
      return u;
    }

    private string MostrarDatos(Universidad uni)
    {
      return " ";
    }

    public override string ToString()
    {
      return " ";
    }

  }
}
