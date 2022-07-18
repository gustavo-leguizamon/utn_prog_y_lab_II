using Entidades;
using Entidades.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    /// <summary>
    /// Pruebas sobre tiempos
    /// 
    /// CLASE 11 - Pruebas unitarias
    /// 
    /// </summary>
    [TestClass]
    public class TiempoTests
    {
        [TestMethod]
        [DataRow(23, 0, 0)]
        [DataRow(15, 0, 0)]
        [DataRow(5, 0, 0)]
        public void Constructor_CuandoSePasaHorasEntre0Y23_DeberiaContruirElObjeto(int horas, int minutos, int segundos)
        {
            //Arrange
            Tiempo tiempo;

            //Act
            tiempo = new Tiempo(horas, minutos, segundos);

            //Assert
            Assert.IsNotNull(tiempo);
        }

        [TestMethod]
        [DataRow(-23, 0, 0)]
        [DataRow(-15, 0, 0)]
        [DataRow(-5, 0, 0)]
        [ExpectedException(typeof(HorarioInvalidoException))]
        public void Constructor_CuandoSePasaHorasMenoresACero_DeberiaLanzarExcepcionDeHorario(int horas, int minutos, int segundos)
        {
            //Arrange
            Tiempo tiempo;

            //Act
            tiempo = new Tiempo(horas, minutos, segundos);
        }

        [TestMethod]
        [DataRow(24, 0, 0)]
        [DataRow(150, 0, 0)]
        [DataRow(35, 0, 0)]
        [ExpectedException(typeof(HorarioInvalidoException))]
        public void Constructor_CuandoSePasaHorasMayoresA23_DeberiaLanzarExcepcionDeHorario(int horas, int minutos, int segundos)
        {
            //Arrange
            Tiempo tiempo;

            //Act
            tiempo = new Tiempo(horas, minutos, segundos);
        }

        [TestMethod]
        [DataRow(0, 45, 0)]
        [DataRow(0, 5, 0)]
        [DataRow(0, 6, 0)]
        public void Constructor_CuandoSePasaMinutosEntre0Y59_DeberiaContruirElObjeto(int horas, int minutos, int segundos)
        {
            //Arrange
            Tiempo tiempo;

            //Act
            tiempo = new Tiempo(horas, minutos, segundos);

            //Assert
            Assert.IsNotNull(tiempo);
        }

        [TestMethod]
        [DataRow(0, -45, 0)]
        [DataRow(0, -5, 0)]
        [DataRow(0, -6, 0)]
        [ExpectedException(typeof(HorarioInvalidoException))]
        public void Constructor_CuandoSePasaMinutosMenoresACero_DeberiaLanzarExcepcionDeHorario(int horas, int minutos, int segundos)
        {
            //Arrange
            Tiempo tiempo;

            //Act
            tiempo = new Tiempo(horas, minutos, segundos);
        }

        [TestMethod]
        [DataRow(0, 60, 0)]
        [DataRow(0, 500, 0)]
        [DataRow(0, 240, 0)]
        [ExpectedException(typeof(HorarioInvalidoException))]
        public void Constructor_CuandoSePasaMinutosMayoresA59_DeberiaLanzarExcepcionDeHorario(int horas, int minutos, int segundos)
        {
            //Arrange
            Tiempo tiempo;

            //Act
            tiempo = new Tiempo(horas, minutos, segundos);
        }

        [TestMethod]
        [DataRow(0, 0, 56)]
        [DataRow(0, 0, 5)]
        [DataRow(0, 0, 9)]
        public void Constructor_CuandoSePasaSegundosEntre0Y59_DeberiaContruirElObjeto(int horas, int minutos, int segundos)
        {
            //Arrange
            Tiempo tiempo;

            //Act
            tiempo = new Tiempo(horas, minutos, segundos);

            //Assert
            Assert.IsNotNull(tiempo);
        }

        [TestMethod]
        [DataRow(0, 0, -56)]
        [DataRow(0, 0, -5)]
        [DataRow(0, 0, -9)]
        [ExpectedException(typeof(HorarioInvalidoException))]
        public void Constructor_CuandoSePasaSegundosMenoresACero_DeberiaLanzarExcepcionDeHorario(int horas, int minutos, int segundos)
        {
            //Arrange
            Tiempo tiempo;

            //Act
            tiempo = new Tiempo(horas, minutos, segundos);
        }

        [TestMethod]
        [DataRow(0, 0, 60)]
        [DataRow(0, 0, 500)]
        [DataRow(0, 0, 90)]
        [ExpectedException(typeof(HorarioInvalidoException))]
        public void Constructor_CuandoSePasaSegundosMayoresA59_DeberiaLanzarExcepcionDeHorario(int horas, int minutos, int segundos)
        {
            //Arrange
            Tiempo tiempo;

            //Act
            tiempo = new Tiempo(horas, minutos, segundos);
        }

        [TestMethod]
        [DataRow(23, 32, 56)]
        [DataRow(15, 23, 5)]
        [DataRow(5, 6, 9)]
        public void Constructor_CuandoSePasaUnHorarioValido_DeberiaContruirElObjeto(int horas, int minutos, int segundos)
        {
            //Arrange
            Tiempo tiempo;

            //Act
            tiempo = new Tiempo(horas, minutos, segundos);

            //Assert
            Assert.IsNotNull(tiempo);
        }

        [TestMethod]
        [DataRow("23:0:0")]
        [DataRow("15:0:0")]
        [DataRow("5:0:0")]
        public void Constructor_CuandoSePasaHorasEntre0Y23EnFormatoStringDeHoraDosPuntosMinutosDosPuntosSegundos_DeberiaContruirElObjeto(string hora)
        {
            //Arrange
            Tiempo tiempo;

            //Act
            tiempo = new Tiempo(hora);

            //Assert
            Assert.IsNotNull(tiempo);
        }

        [TestMethod]
        [DataRow("-23:0:0")]
        [DataRow("-15:0:0")]
        [DataRow("-5:0:0")]
        [ExpectedException(typeof(HorarioInvalidoException))]
        public void Constructor_CuandoSePasaHorasMenoresACeroEnFormatoStringDeHoraDosPuntosMinutosDosPuntosSegundos_DeberiaLanzarExcepcionDeHorario(string hora)
        {
            //Arrange
            Tiempo tiempo;

            //Act
            tiempo = new Tiempo(hora);
        }

        [TestMethod]
        [DataRow("24:0:0")]
        [DataRow("150:0:0")]
        [DataRow("35:0:0")]
        [ExpectedException(typeof(HorarioInvalidoException))]
        public void Constructor_CuandoSePasaHorasMayoresA23EnFormatoStringDeHoraDosPuntosMinutosDosPuntosSegundos_DeberiaLanzarExcepcionDeHorario(string hora)
        {
            //Arrange
            Tiempo tiempo;

            //Act
            tiempo = new Tiempo(hora);
        }

        [TestMethod]
        [DataRow("0:45:0")]
        [DataRow("0:5:0")]
        [DataRow("0:6:0")]
        public void Constructor_CuandoSePasaMinutosEntre0Y59EnFormatoStringDeHoraDosPuntosMinutosDosPuntosSegundos_DeberiaContruirElObjeto(string hora)
        {
            //Arrange
            Tiempo tiempo;

            //Act
            tiempo = new Tiempo(hora);

            //Assert
            Assert.IsNotNull(tiempo);
        }

        [TestMethod]
        [DataRow("0:-45:0")]
        [DataRow("0:-5:0")]
        [DataRow("0:-6:0")]
        [ExpectedException(typeof(HorarioInvalidoException))]
        public void Constructor_CuandoSePasaMinutosMenoresACeroEnFormatoStringDeHoraDosPuntosMinutosDosPuntosSegundos_DeberiaLanzarExcepcionDeHorario(string hora)
        {
            //Arrange
            Tiempo tiempo;

            //Act
            tiempo = new Tiempo(hora);
        }

        [TestMethod]
        [DataRow("0:60:0")]
        [DataRow("0:500:0")]
        [DataRow("0:240:0")]
        [ExpectedException(typeof(HorarioInvalidoException))]
        public void Constructor_CuandoSePasaMinutosMayoresA59EnFormatoStringDeHoraDosPuntosMinutosDosPuntosSegundos_DeberiaLanzarExcepcionDeHorario(string hora)
        {
            //Arrange
            Tiempo tiempo;

            //Act
            tiempo = new Tiempo(hora);
        }

        [TestMethod]
        [DataRow("0:0:56")]
        [DataRow("0:0:5")]
        [DataRow("0:0:9")]
        public void Constructor_CuandoSePasaSegundosEntre0Y59EnFormatoStringDeHoraDosPuntosMinutosDosPuntosSegundos_DeberiaContruirElObjeto(string hora)
        {
            //Arrange
            Tiempo tiempo;

            //Act
            tiempo = new Tiempo(hora);

            //Assert
            Assert.IsNotNull(tiempo);
        }

        [TestMethod]
        [DataRow("0:0:-56")]
        [DataRow("0:0:-5")]
        [DataRow("0:0:-9")]
        [ExpectedException(typeof(HorarioInvalidoException))]
        public void Constructor_CuandoSePasaSegundosMenoresACeroEnFormatoStringDeHoraDosPuntosMinutosDosPuntosSegundos_DeberiaLanzarExcepcionDeHorario(string hora)
        {
            //Arrange
            Tiempo tiempo;

            //Act
            tiempo = new Tiempo(hora);
        }

        [TestMethod]
        [DataRow("0:0:60")]
        [DataRow("0:0:500")]
        [DataRow("0:0:90")]
        [ExpectedException(typeof(HorarioInvalidoException))]
        public void Constructor_CuandoSePasaSegundosMayoresA59EnFormatoStringDeHoraDosPuntosMinutosDosPuntosSegundos_DeberiaLanzarExcepcionDeHorario(string hora)
        {
            //Arrange
            Tiempo tiempo;

            //Act
            tiempo = new Tiempo(hora);
        }

        [TestMethod]
        [DataRow("0::0:12")]
        [DataRow("0:0;50")]
        [DataRow("0:0,:10")]
        [ExpectedException(typeof(HorarioInvalidoException))]
        public void Constructor_CuandoSePasaUnHorarioEnFormatoStringDeHoraDosPuntosMinutosDosPuntosSegundosIncorrecto_DeberiaLanzarExcepcionDeHorario(string hora)
        {
            //Arrange
            Tiempo tiempo;

            //Act
            tiempo = new Tiempo(hora);
        }

        [TestMethod]
        [DataRow("23:32:56")]
        [DataRow("15:23:5")]
        [DataRow("5:6:9")]
        public void Constructor_CuandoSePasaUnHorarioEnFormatoStringDeHoraDosPuntosMinutosDosPuntosSegundosValido_DeberiaContruirElObjeto(string hora)
        {
            //Arrange
            Tiempo tiempo;

            //Act
            tiempo = new Tiempo(hora);

            //Assert
            Assert.IsNotNull(tiempo);
        }

        [TestMethod]
        public void SetHora_CuandoSeAsignaUnaHoraEntre0y23_DeberiaHacerloSinFalla()
        {
            //Arrange
            Tiempo tiempo = new Tiempo(23, 32, 56);

            //Act
            tiempo.Hora = 15;

            //Assert
            Assert.IsNotNull(tiempo);
        }

        [TestMethod]
        [ExpectedException(typeof(HorarioInvalidoException))]
        public void SetHora_CuandoSeAsignaUnaHoraMenorACero_DeberiaLanzarExcepcionDeHorario()
        {
            //Arrange
            Tiempo tiempo = new Tiempo(23, 32, 56);

            //Act
            tiempo.Hora = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(HorarioInvalidoException))]
        public void SetHora_CuandoSeAsignaUnaHoraMayorA23_DeberiaLanzarExcepcionDeHorario()
        {
            //Arrange
            Tiempo tiempo = new Tiempo(23, 32, 56);

            //Act
            tiempo.Hora = 24;
        }

        [TestMethod]
        public void SetMinuto_CuandoSeAsignaUnMinutoEntre0y59_DeberiaHacerloSinFalla()
        {
            //Arrange
            Tiempo tiempo = new Tiempo(23, 32, 56);

            //Act
            tiempo.Minuto = 45;

            //Assert
            Assert.IsNotNull(tiempo);
        }

        [TestMethod]
        [ExpectedException(typeof(HorarioInvalidoException))]
        public void SetHora_CuandoSeAsignaUnMinutoMenorACero_DeberiaLanzarExcepcionDeHorario()
        {
            //Arrange
            Tiempo tiempo = new Tiempo(23, 32, 56);

            //Act
            tiempo.Minuto = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(HorarioInvalidoException))]
        public void SetHora_CuandoSeAsignaUnMinutoMayorA59_DeberiaLanzarExcepcionDeHorario()
        {
            //Arrange
            Tiempo tiempo = new Tiempo(23, 32, 56);

            //Act
            tiempo.Minuto = 61;
        }

        [TestMethod]
        public void SetSegundo_CuandoSeAsignaUnSegundoEntre0y59_DeberiaHacerloSinFalla()
        {
            //Arrange
            Tiempo tiempo = new Tiempo(23, 32, 56);

            //Act
            tiempo.Segundo = 45;

            //Assert
            Assert.IsNotNull(tiempo);
        }

        [TestMethod]
        [ExpectedException(typeof(HorarioInvalidoException))]
        public void SetHora_CuandoSeAsignaUnSegundoMenorACero_DeberiaLanzarExcepcionDeHorario()
        {
            //Arrange
            Tiempo tiempo = new Tiempo(23, 32, 56);

            //Act
            tiempo.Segundo = -1;
        }

        [TestMethod]
        [ExpectedException(typeof(HorarioInvalidoException))]
        public void SetHora_CuandoSeAsignaUnSegundoMayorA59_DeberiaLanzarExcepcionDeHorario()
        {
            //Arrange
            Tiempo tiempo = new Tiempo(23, 32, 56);

            //Act
            tiempo.Segundo = 61;
        }
    }
}
