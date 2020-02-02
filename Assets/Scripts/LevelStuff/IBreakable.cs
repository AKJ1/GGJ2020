using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IBreakable
{
    bool IsBroken { get; }
    //bool CanBeBroken { get; }

    void Break();

    void Fix();

    void RegisterBreakable();
}
