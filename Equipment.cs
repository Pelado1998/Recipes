//-------------------------------------------------------------------------------
// <copyright file="Equipment.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------------

namespace Full_GRASP_And_SOLID
{
    /// <summary>
    /// La clase Equipment cumple con SRP ya que tiene una única razón de cambio (costo).
    /// Tambien con Expert ya que conoce muy bien la información que maneja y es la mejor responsable de esos datos.
    /// </summary>
    public class Equipment
    {
        #region Exceptions
        public class DescriptionException : System.Exception
        {
            public DescriptionException() : base("La descripción no puede ser nulo") { }
        }
        public class DescriptionLengthException : System.Exception
        {
            public DescriptionLengthException() : base("La descripción supera la cantidad de caracteres permitidos") { }
        }
        public class HourleyCostException : System.Exception
        {
            public HourleyCostException() : base("El costo por hora no puede ser negativo") { }
        }
        public class DescriptionNullException : System.Exception
        {
            public DescriptionNullException() : base("La descripción es nula") { }
        }
        public class HourleyCostNullException : System.Exception
        {
            public HourleyCostNullException() : base("El costo por hora es cero") { }
        }
        #endregion

        public Equipment(string description, double hourlyCost)
        {
            #region Preconditions
            if (string.IsNullOrEmpty(description))
            {
                throw new DescriptionException();
            }
            else if(description.Length>=100)
            {
                throw new DescriptionLengthException();
            }
            else if(hourlyCost<0)
            {
                throw new HourleyCostException();
            }
            #endregion
            
            this.Description = description;
            this.HourlyCost = hourlyCost;

            #region Postconditions
            if (string.IsNullOrEmpty(this.Description))
            {
                throw new DescriptionNullException();
            }
            else if(this.HourlyCost == 0)
            {
                throw new HourleyCostNullException();
            }
            #endregion
        }        

        public string Description { get; set; }

        public double HourlyCost { get; set; }
    }
}