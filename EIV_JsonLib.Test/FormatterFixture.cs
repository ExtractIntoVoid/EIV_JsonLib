using EIV_JsonLib.Formatter;
using EIV_JsonLib.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: AssemblyFixture(typeof(FormatterFixture))]

namespace EIV_JsonLib.Test;

public class FormatterFixture : IDisposable
{
    public FormatterFixture()
    {
        FormatterInitializer.RegisterFormatter();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}

