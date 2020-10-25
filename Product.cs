//--------------------------------------------------------------------------------------
// <copyright file="Product.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//---------------------------------------------------------------------------------------

namespace Full_GRASP_And_SOLID
{
    public class Product
    {
        #region Exceptions
        public class DescriptionLengthException : System.Exception
        {
            public DescriptionLengthException() : base("La descripción supera la cantidad de caracteres permitidos") { }
        }
        
        public class DescriptionException : System.Exception
        {
            public DescriptionException() : base("La descripción  no puede ser nulo") { }
        }
        public class UnitCostException : System.Exception
        {
            public UnitCostException() : base("El costo por unidad no puede ser negativo") { }
        }
        public class DescriptionNullException : System.Exception
        {
            public DescriptionNullException() : base("La descripción es nula") { }
        }
        public class UnitCostNullException : System.Exception
        {
            public UnitCostNullException() : base("El costo por unidad es cero") { }
        }
        #endregion

        public Product(string description, double unitCost)
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
            else if(unitCost<0)
            {
                throw new UnitCostException();
            }
            #endregion

            this.Description = description;
            this.UnitCost = unitCost;

            #region Postconditions
            if (string.IsNullOrEmpty(this.Description))
            {
                throw new DescriptionNullException();
            }
            else if(this.UnitCost == 0)
            {
                throw new UnitCostNullException();
            }
            #endregion
        }

        public string Description { get; set; }

        public double UnitCost { get; set; }
    }
}

       

           

