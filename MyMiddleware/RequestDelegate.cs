using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMiddleware
{
    public delegate Task RequestDelegate(Context context);
}
