using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkChallenge.Domain
{
    public class CalculatorDividers
    {
        public DividersDTO Calculate(int Number)
        {
            DividersDTO dividers = new DividersDTO();
            dividers.NumberDividers = new List<int>();
            dividers.NumberDividersPrime = new List<int>();

            for (int i = 1; i <= Number; i++)
            {
                if (Number % i == 0)
                {
                    dividers.NumberDividers.Add(i);
                }
            }

            for (int y = 0; y < dividers.NumberDividers.Count; y++)
            {
                int cont = 0;
                for (int i = dividers.NumberDividers[y]; i > 0; i--)
                {
                    if (dividers.NumberDividers[y] % i == 0)
                    {
                        cont++;
                    }
                }
                if (cont == 2)
                {
                    dividers.NumberDividersPrime.Add(dividers.NumberDividers[y]);
                }
            }

            return dividers;
        }
    }
}